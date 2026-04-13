const { app, BrowserWindow, ipcMain, dialog } = require('electron');
const path = require('node:path');
const fs = require('node:fs');
const { spawn } = require('node:child_process');

const SCRIPTS_FILE = path.join(app.getPath('userData'), 'ps1-scripts.json');

function loadScripts() {
    try {
        if (fs.existsSync(SCRIPTS_FILE)) {
            return JSON.parse(fs.readFileSync(SCRIPTS_FILE, 'utf-8'));
        }
    } catch (_) { /* ignore corrupt file */ }
    return [];
}

function saveScripts(scripts) {
    fs.writeFileSync(SCRIPTS_FILE, JSON.stringify(scripts, null, 2), 'utf-8');
}

let mainWindow;

const createWindow = () => {
    mainWindow = new BrowserWindow({
        width: 900,
        height: 650,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js'),
            contextIsolation: true,
            nodeIntegration: false
        },
        autoHideMenuBar: true
    });

    mainWindow.loadFile('index.html');
};

app.on('ready', () => {
    createWindow();
    app.on('activate', () => {
        if (BrowserWindow.getAllWindows().length === 0) createWindow();
    });
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});

// ── IPC Handlers ────────────────────────────────────────────

ipcMain.handle('get-scripts', () => {
    return loadScripts();
});

ipcMain.handle('browse-scripts', async () => {
    const result = await dialog.showOpenDialog(mainWindow, {
        title: 'Select PowerShell Scripts',
        filters: [{ name: 'PowerShell Scripts', extensions: ['ps1'] }],
        properties: ['openFile', 'multiSelections']
    });
    if (result.canceled) return [];
    const existing = loadScripts();
    const existingPaths = new Set(existing.map(s => s.path));
    const newEntries = result.filePaths
        .filter(p => !existingPaths.has(p))
        .map(p => ({ name: path.basename(p), path: p }));
    const updated = [...existing, ...newEntries];
    saveScripts(updated);
    return updated;
});

ipcMain.handle('remove-script', (_event, scriptPath) => {
    const scripts = loadScripts().filter(s => s.path !== scriptPath);
    saveScripts(scripts);
    return scripts;
});

ipcMain.handle('run-scripts', async (_event, paths) => {
    const results = [];
    for (const filePath of paths) {
        if (!fs.existsSync(filePath)) {
            results.push({ path: filePath, exitCode: -1, stdout: '', stderr: `File not found: ${filePath}` });
            continue;
        }
        const result = await runPs1(filePath);
        results.push(result);
    }
    return results;
});

function runPs1(filePath) {
    return new Promise((resolve) => {
        let stdout = '';
        let stderr = '';
        const proc = spawn('powershell.exe', [
            '-NoProfile',
            '-ExecutionPolicy', 'Bypass',
            '-File', filePath
        ], { windowsHide: true });

        proc.stdout.on('data', (d) => { stdout += d.toString(); });
        proc.stderr.on('data', (d) => { stderr += d.toString(); });
        proc.on('close', (exitCode) => {
            resolve({ path: filePath, exitCode, stdout, stderr });
        });
        proc.on('error', (err) => {
            resolve({ path: filePath, exitCode: -1, stdout: '', stderr: err.message });
        });
    });
}
