const { app, BrowserWindow, ipcMain, dialog } = require('electron');
const path = require('node:path');
const fs = require('node:fs');
const XLSX = require('xlsx');

let mainWindow;

function createWindow() {
    mainWindow = new BrowserWindow({
        width: 1280,
        height: 860,
        minWidth: 900,
        minHeight: 600,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js'),
            contextIsolation: true,
            nodeIntegration: false
        },
        autoHideMenuBar: true,
        title: 'PlateSearch Comparison'
    });
    mainWindow.loadFile('index.html');
}

app.whenReady().then(() => {
    createWindow();
    app.on('activate', () => {
        if (BrowserWindow.getAllWindows().length === 0) createWindow();
    });
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});

ipcMain.handle('save-csv', async (_event, { content, suggestedName }) => {
    const result = await dialog.showSaveDialog(mainWindow, {
        title: 'Save as CSV',
        defaultPath: suggestedName || 'output.csv',
        filters: [{ name: 'CSV', extensions: ['csv'] }]
    });
    if (result.canceled || !result.filePath) return null;
    fs.writeFileSync(result.filePath, content, 'utf-8');
    return result.filePath;
});

ipcMain.handle('save-xlsx', async (_event, { rows, suggestedName }) => {
    const result = await dialog.showSaveDialog(mainWindow, {
        title: 'Save as Excel',
        defaultPath: suggestedName || 'pivot.xlsx',
        filters: [{ name: 'Excel', extensions: ['xlsx'] }]
    });
    if (result.canceled || !result.filePath) return null;
    const wb = XLSX.utils.book_new();
    const ws = XLSX.utils.aoa_to_sheet(rows);
    XLSX.utils.book_append_sheet(wb, ws, 'Pivot');
    XLSX.writeFile(wb, result.filePath);
    return result.filePath;
});

ipcMain.handle('write-file', async (_event, { filePath, content }) => {
    try {
        fs.writeFileSync(filePath, content, 'utf-8');
        return filePath;
    } catch (e) {
        return { error: e.message };
    }
});

ipcMain.handle('open-file', async () => {
    const result = await dialog.showOpenDialog(mainWindow, {
        title: 'Open Spreadsheet',
        filters: [{ name: 'Spreadsheets', extensions: ['xlsx', 'xls', 'csv'] }],
        properties: ['openFile']
    });
    if (result.canceled || !result.filePaths.length) return null;

    try {
        const wb = XLSX.readFile(result.filePaths[0]);
        const ws = wb.Sheets[wb.SheetNames[0]];
        const data = XLSX.utils.sheet_to_json(ws, { header: 1, defval: null });
        const csvContent = XLSX.utils.sheet_to_csv(ws);
        return { filePath: result.filePaths[0], data, csvContent };
    } catch (e) {
        return { error: e.message };
    }
});
