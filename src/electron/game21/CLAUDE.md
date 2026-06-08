# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this app does

**PlateSearch Comparison** is an Electron desktop tool that reads an Excel/CSV spreadsheet of performance test results and renders a horizontal bar chart comparing multiple VM runs, along with a statistics summary table.

**Input format** — two formats are supported automatically:

*Pivot format* (see `temp/input.jpg`):
- Row 1: blank column A, VM run names in columns B, C, D… (e.g. `VM80.Prod.270 [2026-06-01_1400] Per.01`)
- Row 2 (optional): `Test Case Descriptions` label in column A — this row is skipped
- Rows 3+: case label in column A, numeric duration values in columns B, C, D…

*Flat/normalized format* (e.g. `temp/duration-report-*.csv`):
- Row 1: named column headers — detection keys are `Run User` and `Duration (seconds)`
- Rows 2+: one record per (test case, run user) execution — relevant columns: `Test case No.`, `Test Case Descriptions`, `Run User`, `Duration (seconds)`
- On load the app auto-converts to a pivot (see below) and saves it as `<source>-pivot.csv` next to the source file

**Flat → pivot conversion**: When a flat file is opened, `parseFlatData` groups records by `(Test case No., Run User)`, computes `avg(Duration)` per group, and writes a `<source>-pivot.csv` alongside the source file. The pivot format is: `Test case No. | Test Case Descriptions | Per.01 Duration | Per.02 Duration | … | Average Time`. The chart is then drawn using the pivot data (run users as datasets, per-case averages as values fed into `calcStats`).

**Output** (see `temp/output.jpg`): A horizontal bar chart titled "Comparision PlateSearch" comparing statistics per run user: Total Test Case, Average, Median, configurable percentiles (default: 80%, 90%, 95%, 99%), and Max Duration — plus a matching summary table below. A toggle bar lets you show/hide individual stats; percentile toggles can be removed (×) or new ones added via the **+ P** input.

**Theming**: A **Theme** button in the header opens a dropdown to switch between three built-in themes (Blue, Dark, Light). A **"Customize colors…"** option in that dropdown opens a slide-in panel listing ~18 CSS-variable-backed color pickers grouped by Background / Text / Borders / Accent & Buttons / Chart. Changes apply instantly; customizations are saved per theme to `localStorage` and restored on next launch. Reset clears overrides for the active theme.

**Chart bar colors**: The colored square in the left column of the stats table is a native `<input type="color">`. Clicking it opens the OS color picker; dragging updates the chart bars live (`chartInstance.update('none')` — no DOM rebuild). On picker close the color is saved to `localStorage` under key `chartColors` and a full `renderAll()` syncs the table swatch. Colors persist across file loads and theme switches.

## Commands

```bash
npm install      # install dependencies (chart.js, chartjs-plugin-datalabels, xlsx, electron)
npm start        # run in dev mode
npm run build    # produce a portable .exe in dist/
```

## Architecture

Three-process Electron model with context isolation:

| File | Role |
|---|---|
| `main.js` | Main process: creates `BrowserWindow`, handles `open-file` IPC (dialog + `xlsx` read), `save-csv` (save dialog), `write-file` (silent write to path) |
| `preload.js` | Context bridge: exposes `window.api.openFile()`, `saveCSV()`, `writeFile()` |
| `renderer.js` | Renderer: `parseData()` detects VM header row, `calcStats()` computes percentiles, `renderChart()` builds Chart.js horizontal bar chart, `renderTable()` builds the HTML stats table, `applyTheme()` switches themes, `buildColorPanel()` populates the customize panel |
| `index.html` | Loads `chart.js` and `chartjs-plugin-datalabels` UMD bundles from `node_modules/`, hosts `<canvas id="chartCanvas">`, `<table id="statsTable">`, `#colorPanel` (slide-in customizer), and three CSS theme variable blocks (`[data-theme="blue/dark/light"]`) |

**Data flow (pivot format):** `dialog.showOpenDialog` → `XLSX.readFile` (main) → `ipcMain.handle('open-file')` → `window.api.openFile()` (preload) → `parseData` + `calcStats` + `renderChart` + `renderTable` (renderer).

**Data flow (flat format):** same open path → `isFlatFormat` detected → `parseFlatData` → computes avg per `(Test case No., Run User)` → writes `<source>-pivot.csv` via `window.api.writeFile()` → feeds `{headers, columns}` into existing `calcStats` + `renderChart` + `renderTable`.

**Parsing logic** (`renderer.js → parseData`): Calls `isFlatFormat` first — detects by checking row 0 for both `run user` and `duration (seconds)` column headers. If flat: `parseFlatData` groups by `(caseNo, runUser)`, averages durations, produces `columns[userIdx] = [perCaseAvg…]` (nulls filtered), generates `pivotCsv` string, sets `format: 'flat-pivot'`. Otherwise: scans rows until columns B+ have non-empty values — those become dataset labels. Subsequent rows with non-empty col A (except `test case descriptions`) are data rows; each is an independent test case. Null/empty cells excluded; non-numeric → `0`.

**Stats** (`renderer.js → calcStats`): Linear-interpolation percentiles computed dynamically from `customPercentiles` array, plus fixed stats: average, median (p50), total count, and max. All rounded to 2 decimal places.

**Dynamic percentiles** (`renderer.js`): `customPercentiles` (default `[80, 90, 95, 99]`) drives both `calcStats` and `buildSTATS()`. `renderToggles()` rebuilds the toggle bar pills whenever percentiles are added or removed. Adding: type 1–99 in the **+ P** input and press Enter or click the button. Removing: click × on any percentile pill.

**Chart height / scroll** (`renderer.js → renderChart`, `index.html`): Canvas height is computed dynamically as `activeStats × (datasets × rowH + 12) + 180px`. `.chart-wrapper` uses `overflow-y: auto; max-height: calc(100vh - 220px)` so the chart scrolls when it overflows. `maxBarThickness: rowH` prevents bars from overlapping across groups. The **Row px** input (right side of the toggle bar, default 28, range 4–200) controls per-bar pixel height; changing it triggers `renderAll`. `getRowHeight()` reads this input.

**Chart** uses Chart.js 4.x with `indexAxis: 'y'` (horizontal) and `chartjs-plugin-datalabels` (registered per-chart via the `plugins: [ChartDataLabels]` config array) to show values at the end of each bar. Only stats with their toggle checked are rendered. Chart text/grid colors are read at render time from CSS variables via `cssVar()` so they update correctly on theme change.

**Theming** (`renderer.js → applyTheme`, `loadColorOverrides`, `saveColorOverrides`): Sets `data-theme` attribute on `<html>`, loads any per-theme color overrides from `localStorage` as inline `style` properties on `documentElement`, then triggers `renderAll`. Theme choice saved as `appTheme`; per-theme overrides saved as `appColors_<theme>`.

**Chart colors** (`renderer.js → chartColors`, `getChartColor`): `chartColors` is a sparse object `{index: hexColor}` loaded from `localStorage` key `chartColors`. `getChartColor(i)` falls back to `COLORS[i % COLORS.length]` for indices with no override. The `input` event on table swatches patches `chartInstance.data.datasets[i].backgroundColor` directly and calls `chartInstance.update('none')` to avoid rebuilding the table DOM (which would close the OS color picker). The `change` event (picker close) persists and calls `renderAll()`.

## Test helper

`drive.mjs` is a Playwright `_electron` driver. Run with `node drive.mjs` to launch the app, inject sample data via `window._testLoad()`, and save screenshots to `temp/shots/`. Requires `playwright-core` (in `devDependencies`).
