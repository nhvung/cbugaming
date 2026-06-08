const COLORS = ['#969696', '#e07533', '#4472c4', '#ffc000', '#70ad47', '#c55a11', '#a9d18e', '#9dc3e6'];

const COLOR_GROUPS = [
    { label: 'Background', vars: [
        { v: '--bg',         n: 'App background' },
        { v: '--bg-header',  n: 'Header / toolbar' },
        { v: '--bg-input',   n: 'Input fields' },
        { v: '--bg-toggle',  n: 'Toggle bar' },
        { v: '--bg-td',      n: 'Table cells' },
        { v: '--bg-th',      n: 'Table headers' },
    ]},
    { label: 'Text', vars: [
        { v: '--text',       n: 'Primary text' },
        { v: '--text-muted', n: 'Muted / info text' },
        { v: '--text-th',    n: 'Table header text' },
        { v: '--text-td',    n: 'Table cell text' },
        { v: '--text-vm',    n: 'VM name text' },
    ]},
    { label: 'Borders', vars: [
        { v: '--border',       n: 'Main border' },
        { v: '--border-input', n: 'Input border' },
        { v: '--border-td',    n: 'Table cell border' },
    ]},
    { label: 'Accent & Buttons', vars: [
        { v: '--accent',       n: 'Accent (buttons, active)' },
        { v: '--accent-hover', n: 'Accent hover' },
        { v: '--row-hover',    n: 'Table row hover' },
    ]},
    { label: 'Chart', vars: [
        { v: '--chart-text',  n: 'Axis labels & legend' },
        { v: '--chart-title', n: 'Title & data labels' },
    ]},
];

let customPercentiles = [80, 90, 95, 99];

function buildSTATS() {
    const pStats = [...customPercentiles].sort((a, b) => a - b)
        .map(p => ({ key: `p${p}`, label: `${p}%`, percentile: p }));
    return [
        { key: 'total',  label: 'Total Test Case' },
        { key: 'avg',    label: 'Average' },
        { key: 'median', label: 'Median' },
        ...pStats,
        { key: 'max',    label: 'Max Duration' },
    ];
}

let currentParsed = null;
let currentCSV = null;
let currentFileName = null;
let chartInstance = null;
let chartColors = {};  // index → custom color override

function getChartColor(i) {
    return chartColors[i] !== undefined ? chartColors[i] : COLORS[i % COLORS.length];
}

function saveChartColors() {
    localStorage.setItem('chartColors', JSON.stringify(chartColors));
}

(function loadChartColors() {
    try { chartColors = JSON.parse(localStorage.getItem('chartColors') || '{}'); } catch {}
})();

function getRowHeight() {
    return Math.max(4, parseInt(document.getElementById('rowHeightInput')?.value, 10) || 28);
}

// ── Statistics ────────────────────────────────────────────

function percentile(sorted, p) {
    const n = sorted.length;
    if (!n) return 0;
    const idx = (p / 100) * (n - 1);
    const lo = Math.floor(idx);
    const hi = Math.ceil(idx);
    return lo === hi ? sorted[lo] : sorted[lo] + (sorted[hi] - sorted[lo]) * (idx - lo);
}

function round2(n) {
    return Math.round(n * 100) / 100;
}

function calcStats(values) {
    const empty = { total: 0, avg: 0, median: 0, max: 0 };
    customPercentiles.forEach(p => { empty[`p${p}`] = 0; });
    if (!values.length) return empty;
    const sorted = [...values].sort((a, b) => a - b);
    const total = sorted.length;
    const result = {
        total,
        avg: round2(values.reduce((s, v) => s + v, 0) / total),
        median: round2(percentile(sorted, 50)),
        max: round2(sorted[total - 1])
    };
    customPercentiles.forEach(p => { result[`p${p}`] = round2(percentile(sorted, p)); });
    return result;
}

function activeStats() {
    return buildSTATS().filter(s => {
        const el = document.querySelector(`input[data-stat="${s.key}"]`);
        return el ? el.checked : true;
    });
}

// ── Toggle bar ────────────────────────────────────────────

function renderToggles() {
    const bar = document.getElementById('toggleBar');
    const prevChecked = {};
    bar.querySelectorAll('input[type="checkbox"]').forEach(cb => {
        prevChecked[cb.dataset.stat] = cb.checked;
    });

    const pills = buildSTATS().map(s => {
        const checked = prevChecked[s.key] !== undefined ? prevChecked[s.key] : true;
        const rm = s.percentile !== undefined
            ? `<span class="rm-p" data-p="${s.percentile}" title="Remove">×</span>`
            : '';
        return `<label class="toggle-pill">
            <input type="checkbox" data-stat="${s.key}"${checked ? ' checked' : ''}>
            ${s.label}${rm}
        </label>`;
    }).join('');

    // Preserve row-height input value across rebuilds
    const prevRowH = document.getElementById('rowHeightInput')?.value || '28';

    bar.innerHTML = pills + `
        <div class="add-p-group">
            <input id="addPInput" type="number" min="1" max="99" placeholder="e.g. 75">
            <button id="addPBtn">+ P</button>
        </div>
        <div class="row-h-group">
            <label for="rowHeightInput">Row px</label>
            <input id="rowHeightInput" type="number" min="10" max="200" value="${prevRowH}">
        </div>`;

    bar.querySelectorAll('input[type="checkbox"]').forEach(cb => {
        cb.addEventListener('change', renderAll);
    });
    bar.querySelectorAll('.rm-p').forEach(btn => {
        btn.addEventListener('click', e => {
            e.preventDefault();
            customPercentiles = customPercentiles.filter(x => x !== +btn.dataset.p);
            renderToggles();
            renderAll();
        });
    });
    document.getElementById('addPBtn').addEventListener('click', addPercentileFromInput);
    document.getElementById('addPInput').addEventListener('keydown', e => {
        if (e.key === 'Enter') addPercentileFromInput();
    });
    document.getElementById('rowHeightInput').addEventListener('change', renderAll);
}

function addPercentileFromInput() {
    const input = document.getElementById('addPInput');
    const p = parseInt(input.value, 10);
    input.value = '';
    if (!p || p < 1 || p > 99 || customPercentiles.includes(p)) return;
    customPercentiles.push(p);
    customPercentiles.sort((a, b) => a - b);
    renderToggles();
    renderAll();
}

// ── Parsing ───────────────────────────────────────────────

function isHeaderRow(row) {
    // A valid header row has a blank/empty col A and at least one non-empty string in cols B+
    const colABlank = row[0] == null || String(row[0]).trim() === '';
    const hasVmNames = row.slice(1).some(c => c != null && String(c).trim() !== '');
    return colABlank && hasVmNames;
}

// Flat format: one row per (test case, run user), with named columns
function isFlatFormat(rawData) {
    if (!rawData || !rawData.length) return false;
    const cols = rawData[0].map(c => c == null ? '' : String(c).trim().toLowerCase());
    return cols.includes('run user') && cols.includes('duration (seconds)');
}

function parseFlatData(rawData) {
    const hdrs = rawData[0].map(c => c == null ? '' : String(c).trim());
    const caseNoCol   = hdrs.findIndex(h => h.toLowerCase() === 'test case no.');
    const caseDescCol = hdrs.findIndex(h => h.toLowerCase() === 'test case descriptions');
    const runUserCol  = hdrs.findIndex(h => h.toLowerCase() === 'run user');
    const durationCol = hdrs.findIndex(h => h.toLowerCase() === 'duration (seconds)');
    if (durationCol < 0) return null;

    // First pass: collect ordered cases and sorted run users
    const caseOrder = [];
    const caseLabel = new Map();
    const userSeen  = new Set();

    for (let i = 1; i < rawData.length; i++) {
        const row = rawData[i];
        if (row[durationCol] == null || row[durationCol] === '') continue;
        const no   = caseNoCol >= 0 && row[caseNoCol] != null ? String(row[caseNoCol]).trim() : String(i);
        const desc = caseDescCol >= 0 && row[caseDescCol] != null ? String(row[caseDescCol]).trim() : '';
        const user = runUserCol >= 0 && row[runUserCol] != null ? String(row[runUserCol]).trim() : '';
        if (!caseLabel.has(no)) { caseOrder.push(no); caseLabel.set(no, desc || `Case ${no}`); }
        if (user) userSeen.add(user);
    }

    const runUsers = [...userSeen].sort();

    // Second pass: accumulate durations per (case, user)
    const raw = new Map();
    caseOrder.forEach(no => { raw.set(no, new Map()); runUsers.forEach(u => raw.get(no).set(u, [])); });

    for (let i = 1; i < rawData.length; i++) {
        const row = rawData[i];
        const dur = row[durationCol];
        if (dur == null || dur === '') continue;
        const no   = caseNoCol >= 0 && row[caseNoCol] != null ? String(row[caseNoCol]).trim() : String(i);
        const user = runUserCol >= 0 && row[runUserCol] != null ? String(row[runUserCol]).trim() : '';
        if (!raw.has(no) || !user) continue;
        const num = +dur;
        raw.get(no).get(user)?.push(isNaN(num) ? 0 : num);
    }

    // Compute avg per (case, user)
    const avgMatrix = new Map();
    caseOrder.forEach(no => {
        const m = {};
        runUsers.forEach(u => {
            const vals = raw.get(no).get(u);
            m[u] = vals && vals.length ? round2(vals.reduce((a, b) => a + b, 0) / vals.length) : null;
        });
        avgMatrix.set(no, m);
    });

    const caseLabels = caseOrder.map(no => `Case ${no}: ${caseLabel.get(no)}`);

    // Pivot rows (2D array) — header + one row per test case
    const pivotRows = [
        ['Test case No.', 'Test Case Descriptions', ...runUsers.map(u => `${u} Duration`), 'Average Time'],
        ...caseOrder.map(no => {
            const vals = runUsers.map(u => avgMatrix.get(no)[u] ?? null);
            const numeric = vals.filter(v => v !== null);
            const avg = numeric.length ? round2(numeric.reduce((a, b) => a + b, 0) / numeric.length) : null;
            return [+no, caseLabel.get(no), ...vals, avg];
        })
    ];

    // columns[userIdx] = per-case avg values → fed into existing calcStats
    const columns = runUsers.map(u =>
        caseOrder.map(no => avgMatrix.get(no)[u] ?? 0).filter(v => v !== 0)
    );

    return {
        format: 'flat-pivot',
        headers: runUsers,
        columns,
        pivotRows,
        headerRowIdx: 0
    };
}

function parseData(rawData) {
    if (!rawData || !rawData.length) return null;

    if (isFlatFormat(rawData)) return parseFlatData(rawData);

    // Prefer row 0 as the header when it matches the expected shape (blank col A, VM names in B+).
    // Fall back to scanning all rows so files with leading blank rows still work.
    let headerRowIdx = -1;
    if (isHeaderRow(rawData[0])) {
        headerRowIdx = 0;
    } else {
        for (let i = 0; i < rawData.length; i++) {
            if (rawData[i].slice(1).some(c => c != null && String(c).trim() !== '')) {
                headerRowIdx = i;
                break;
            }
        }
    }
    if (headerRowIdx < 0) return null;

    // Map each header column index to its VM name (skip nulls/empty)
    const headerRow = rawData[headerRowIdx];
    const colMap = [];
    for (let j = 1; j < headerRow.length; j++) {
        const h = headerRow[j];
        if (h != null && String(h).trim()) colMap.push({ j, name: String(h).trim() });
    }
    if (!colMap.length) return null;

    // Collect numeric values per VM column; each row is an independent test case
    const columns = colMap.map(() => []);
    for (let i = headerRowIdx + 1; i < rawData.length; i++) {
        const row = rawData[i];
        const label = row[0];
        if (!label || String(label).trim().toLowerCase() === 'test case descriptions') continue;
        colMap.forEach(({ j }, idx) => {
            const v = row[j];
            if (v != null && v !== '') {
                const num = +v;
                columns[idx].push(isNaN(num) ? 0 : num);
            }
        });
    }

    return { headers: colMap.map(c => c.name), columns, headerRowIdx };
}

// ── Chart ─────────────────────────────────────────────────

function cssVar(name) {
    return getComputedStyle(document.documentElement).getPropertyValue(name).trim();
}

function renderChart(headers, allStats, title) {
    const canvas = document.getElementById('chartCanvas');
    if (chartInstance) { chartInstance.destroy(); chartInstance = null; }

    const active = [...activeStats()].reverse(); // chart shows max→total top-to-bottom
    const labels = active.map(s => s.label);

    const rowH = getRowHeight();
    // Each stat group needs (numDatasets × rowH) px for bars + 12px gap between groups
    const canvasH = active.length * (headers.length * rowH + 12) + 180;
    canvas.style.height = canvasH + 'px';

    const chartText  = cssVar('--chart-text');
    const chartTitle = cssVar('--chart-title');
    const chartGrid  = cssVar('--chart-grid');
    const chartScale = cssVar('--chart-scale');

    chartInstance = new Chart(canvas, {
        type: 'bar',
        plugins: [ChartDataLabels],
        data: {
            labels,
            datasets: allStats.map((s, i) => ({
                label: headers[i],
                data: active.map(stat => s[stat.key]),
                backgroundColor: getChartColor(i),
                maxBarThickness: rowH
            }))
        },
        options: {
            indexAxis: 'y',
            responsive: true,
            maintainAspectRatio: false,
            layout: { padding: { right: 70, top: 10, bottom: 10 } },
            plugins: {
                title: {
                    display: true,
                    text: title,
                    color: chartTitle,
                    font: { size: 20, weight: 'bold' },
                    padding: { bottom: 20 }
                },
                legend: {
                    position: 'bottom',
                    labels: {
                        color: chartText,
                        padding: 20,
                        font: { size: 11 },
                        boxWidth: 18,
                        boxHeight: 14
                    }
                },
                datalabels: {
                    color: chartTitle,
                    anchor: 'end',
                    align: 'end',
                    offset: 4,
                    font: { size: 10 },
                    formatter: v => Number.isInteger(v) ? v : v.toFixed(2)
                }
            },
            scales: {
                x: {
                    ticks: { color: chartText, font: { size: 11 } },
                    grid: { color: chartGrid },
                    border: { color: chartScale }
                },
                y: {
                    ticks: { color: chartText, font: { size: 12 } },
                    grid: { color: chartGrid },
                    border: { color: chartScale }
                }
            }
        }
    });
}

// ── Table ─────────────────────────────────────────────────

function renderTable(headers, allStats) {
    const active = activeStats();
    document.querySelector('#statsTable thead tr').innerHTML =
        '<th></th>' + active.map(s => `<th>${s.label}</th>`).join('');
    const tbody = document.querySelector('#statsTable tbody');
    tbody.innerHTML = allStats.map((s, i) => `
        <tr>
            <td class="vm-cell">
                <input type="color" class="swatch" data-idx="${i}" value="${getChartColor(i)}" title="Click to change color">
                <span class="vm-name">${escHtml(headers[i]).replace(/\s+/g, '<br>')}</span>
            </td>
            ${active.map(stat => `<td>${s[stat.key]}</td>`).join('')}
        </tr>
    `).join('');

    tbody.querySelectorAll('input.swatch[type="color"]').forEach(input => {
        // While dragging: update chart in-place without rebuilding the DOM
        input.addEventListener('input', () => {
            const i = +input.dataset.idx;
            chartColors[i] = input.value;
            if (chartInstance && chartInstance.data.datasets[i]) {
                chartInstance.data.datasets[i].backgroundColor = input.value;
                chartInstance.update('none');
            }
        });
        // On close: persist and do full sync
        input.addEventListener('change', () => {
            chartColors[+input.dataset.idx] = input.value;
            saveChartColors();
            renderAll();
        });
    });
}

function escHtml(str) {
    return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
}

// ── Main ──────────────────────────────────────────────────

function renderAll() {
    if (!currentParsed) return;
    const title = document.getElementById('chartTitle').value.trim() || 'Comparision PlateSearch';
    const allStats = currentParsed.columns.map(calcStats);
    renderChart(currentParsed.headers, allStats, title);
    renderTable(currentParsed.headers, allStats);
    document.getElementById('resultSection').style.display = '';
}

document.getElementById('btnOpen').addEventListener('click', async () => {
    const res = await window.api.openFile();
    if (!res) return;
    if (res.error) {
        document.getElementById('statusMsg').textContent = 'Error: ' + res.error;
        return;
    }
    currentParsed = parseData(res.data);
    if (!currentParsed) {
        const s = document.getElementById('statusMsg');
        s.style.color = '';
        s.textContent = 'Could not detect VM headers. Ensure column B+ has VM name headers.';
        return;
    }
    currentCSV = res.csvContent || null;
    currentFileName = res.filePath.replace(/\\/g, '/').split('/').pop().replace(/\.[^.]+$/, '') + '.csv';

    document.getElementById('filePath').textContent = res.filePath;
    const statusEl = document.getElementById('statusMsg');
    statusEl.style.color = '#70ad47';
    if (currentParsed.format === 'flat-pivot') {
        const nu = currentParsed.headers.length;
        statusEl.textContent = `Flat format detected (${nu} run users). Click Save to export pivot as .xlsx.`;
    } else {
        const hRow = currentParsed.headerRowIdx;
        if (hRow === 0) {
            statusEl.textContent = `Row 1 confirmed as header (${currentParsed.headers.length} VM column${currentParsed.headers.length !== 1 ? 's' : ''} found).`;
        } else {
            statusEl.style.color = '#e07533';
            statusEl.textContent = `Warning: row 1 is not a valid header — using row ${hRow + 1} instead.`;
        }
    }
    document.getElementById('emptyState').style.display = 'none';
    document.getElementById('btnSaveCSV').disabled = false;
    renderAll();
});

document.getElementById('chartTitle').addEventListener('input', renderAll);

renderToggles();

document.getElementById('btnSaveCSV').addEventListener('click', async () => {
    let savedPath;
    if (currentParsed?.pivotRows) {
        const base = currentFileName.replace(/\.[^.]+$/, '');
        savedPath = await window.api.saveXlsx(currentParsed.pivotRows, base + '.xlsx');
    } else {
        if (!currentCSV) return;
        savedPath = await window.api.saveCSV(currentCSV, currentFileName);
    }
    if (savedPath) {
        document.getElementById('statusMsg').textContent = 'Saved: ' + savedPath;
        setTimeout(() => { document.getElementById('statusMsg').textContent = ''; }, 4000);
    }
});

// ── Theme picker ──────────────────────────────────────────

(function initTheme() {
    const saved = localStorage.getItem('appTheme') || 'blue';
    applyTheme(saved);

    const btn = document.getElementById('btnTheme');
    const dropdown = document.getElementById('themeDropdown');

    btn.addEventListener('click', e => {
        e.stopPropagation();
        dropdown.classList.toggle('open');
    });

    document.addEventListener('click', () => dropdown.classList.remove('open'));

    dropdown.querySelectorAll('.theme-opt').forEach(opt => {
        opt.addEventListener('click', () => {
            applyTheme(opt.dataset.theme);
            dropdown.classList.remove('open');
        });
    });
})();

function applyTheme(theme) {
    document.documentElement.setAttribute('data-theme', theme);
    localStorage.setItem('appTheme', theme);
    loadColorOverrides(theme);
    document.querySelectorAll('.theme-opt').forEach(opt => {
        opt.classList.toggle('active', opt.dataset.theme === theme);
    });
    if (currentParsed) renderAll();
    if (document.getElementById('colorPanel').classList.contains('open')) buildColorPanel();
}

// ── Color customization panel ─────────────────────────────

function rgbToHex(val) {
    val = (val || '').trim();
    if (val.startsWith('#')) return val;
    const m = val.match(/rgb\(\s*(\d+),\s*(\d+),\s*(\d+)\s*\)/);
    if (!m) return '#000000';
    return '#' + [m[1], m[2], m[3]].map(x => parseInt(x).toString(16).padStart(2, '0')).join('');
}

function getVarValue(name) {
    return rgbToHex(getComputedStyle(document.documentElement).getPropertyValue(name));
}

function buildColorPanel() {
    const body = document.getElementById('colorPanelBody');
    body.innerHTML = COLOR_GROUPS.map(g => `
        <div class="cg-title">${g.label}</div>
        ${g.vars.map(({ v, n }) => `
            <div class="color-row">
                <label for="cp${v.replace('--', '')}">${n}</label>
                <input type="color" id="cp${v.replace('--', '')}" data-var="${v}" value="${getVarValue(v)}">
            </div>
        `).join('')}
    `).join('');

    body.querySelectorAll('input[type="color"]').forEach(input => {
        input.addEventListener('input', () => {
            document.documentElement.style.setProperty(input.dataset.var, input.value);
            saveColorOverrides();
            if (currentParsed) renderAll();
        });
    });
}

function saveColorOverrides() {
    const theme = document.documentElement.getAttribute('data-theme') || 'blue';
    const overrides = {};
    COLOR_GROUPS.forEach(g => g.vars.forEach(({ v }) => {
        const val = document.documentElement.style.getPropertyValue(v);
        if (val) overrides[v] = val;
    }));
    localStorage.setItem(`appColors_${theme}`, JSON.stringify(overrides));
}

function loadColorOverrides(theme) {
    COLOR_GROUPS.forEach(g => g.vars.forEach(({ v }) => {
        document.documentElement.style.removeProperty(v);
    }));
    try {
        const saved = JSON.parse(localStorage.getItem(`appColors_${theme}`) || 'null');
        if (saved) Object.entries(saved).forEach(([k, val]) => {
            document.documentElement.style.setProperty(k, val);
        });
    } catch {}
}

document.getElementById('btnCustomizeColors').addEventListener('click', () => {
    document.getElementById('themeDropdown').classList.remove('open');
    buildColorPanel();
    document.getElementById('colorPanel').classList.add('open');
});

document.getElementById('btnClosePanel').addEventListener('click', () => {
    document.getElementById('colorPanel').classList.remove('open');
});

document.getElementById('btnResetColors').addEventListener('click', () => {
    const theme = document.documentElement.getAttribute('data-theme') || 'blue';
    localStorage.removeItem(`appColors_${theme}`);
    COLOR_GROUPS.forEach(g => g.vars.forEach(({ v }) => {
        document.documentElement.style.removeProperty(v);
    }));
    buildColorPanel();
    if (currentParsed) renderAll();
});

// Test hook — injected by automated driver only
window._testLoad = (rawData) => {
    currentParsed = parseData(rawData);
    if (currentParsed) {
        document.getElementById('filePath').textContent = '[test data]';
        document.getElementById('emptyState').style.display = 'none';
        renderAll();
    }
};
