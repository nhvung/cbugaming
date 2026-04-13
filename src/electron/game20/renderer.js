const scriptList = document.getElementById('scriptList');
const outputPanel = document.getElementById('outputPanel');
const statusBar = document.getElementById('statusBar');
const btnBrowse = document.getElementById('btnBrowse');
const btnRun = document.getElementById('btnRun');
const btnSelectAll = document.getElementById('btnSelectAll');

let scripts = [];

// ── Render ──────────────────────────────────────────────────

function render() {
    if (scripts.length === 0) {
        scriptList.innerHTML = '<div class="empty">No scripts added yet. Click <b>+ Add Scripts</b> to browse .ps1 files.</div>';
        btnRun.disabled = true;
        return;
    }

    scriptList.innerHTML = scripts.map((s, i) => `
        <div class="script-item">
            <input type="checkbox" data-index="${i}" class="chk" />
            <div class="info">
                <div class="name">${escapeHtml(s.name)}</div>
                <div class="path" title="${escapeHtml(s.path)}">${escapeHtml(s.path)}</div>
            </div>
            <button class="btn-remove" data-path="${escapeHtml(s.path)}" title="Remove">&times;</button>
        </div>
    `).join('');

    updateRunButton();
}

function escapeHtml(str) {
    const div = document.createElement('div');
    div.textContent = str;
    return div.innerHTML;
}

function getCheckedPaths() {
    return [...document.querySelectorAll('.chk:checked')].map(cb => {
        const idx = parseInt(cb.dataset.index);
        return scripts[idx].path;
    });
}

function updateRunButton() {
    btnRun.disabled = getCheckedPaths().length === 0;
}

function setStatus(text, cls) {
    statusBar.textContent = text;
    statusBar.className = 'status-bar ' + cls;
}

// ── Events ──────────────────────────────────────────────────

scriptList.addEventListener('change', (e) => {
    if (e.target.classList.contains('chk')) updateRunButton();
});

scriptList.addEventListener('click', async (e) => {
    if (e.target.classList.contains('btn-remove')) {
        const p = e.target.dataset.path;
        scripts = await window.api.removeScript(p);
        render();
    }
});

btnBrowse.addEventListener('click', async () => {
    scripts = await window.api.browseScripts();
    render();
});

btnSelectAll.addEventListener('click', () => {
    const boxes = document.querySelectorAll('.chk');
    const allChecked = [...boxes].every(cb => cb.checked);
    boxes.forEach(cb => cb.checked = !allChecked);
    updateRunButton();
});

btnRun.addEventListener('click', async () => {
    const paths = getCheckedPaths();
    if (paths.length === 0) return;

    btnRun.disabled = true;
    setStatus(`Running ${paths.length} script(s)...`, 'running');
    outputPanel.innerHTML = '';

    try {
        const results = await window.api.runScripts(paths);
        for (const r of results) {
            const name = r.path.split('\\').pop().split('/').pop();
            appendOutput(`\n── ${name} (exit: ${r.exitCode}) ──`, 'run-header');
            if (r.stdout) appendOutput(r.stdout, 'run-ok');
            if (r.stderr) appendOutput(r.stderr, 'run-err');
        }
        setStatus(`Finished ${results.length} script(s)`, 'idle');
    } catch (err) {
        appendOutput('Error: ' + err.message, 'run-err');
        setStatus('Error', 'idle');
    }

    updateRunButton();
});

function appendOutput(text, cls) {
    const div = document.createElement('div');
    div.className = cls;
    div.textContent = text;
    outputPanel.appendChild(div);
    outputPanel.scrollTop = outputPanel.scrollHeight;
}

// ── Init ────────────────────────────────────────────────────

(async () => {
    scripts = await window.api.getScripts();
    render();
})();
