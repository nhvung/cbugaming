import { _electron as electron } from 'playwright-core';
import { fileURLToPath } from 'node:url';
import path from 'node:path';
import fs from 'node:fs';

const APP_DIR = path.dirname(fileURLToPath(import.meta.url));
const SHOT_DIR = process.env.SCREENSHOT_DIR || path.join(APP_DIR, 'temp', 'shots');
fs.mkdirSync(SHOT_DIR, { recursive: true });

const electronBin = path.join(APP_DIR, 'node_modules', 'electron', 'dist', 'electron.exe');

// Full sample CSV data (flat format, 12 cases × 7 run users)
const FLAT_RAW = [
    ['Test case No.','Test Case Descriptions','Worker Index','Run User','AuthorizeReason','Type','Total Records Text','Duration (seconds)','Result'],
    [1,'Search Default: without Plate Number + default others filter',4,'Per.08','','PlateSearch','',14.36,'Pass'],
    [1,'Search Default: without Plate Number + default others filter',5,'Per.09','','PlateSearch','',15.61,'Pass'],
    [1,'Search Default: without Plate Number + default others filter',1,'Per.02','','PlateSearch','',14.54,'Pass'],
    [1,'Search Default: without Plate Number + default others filter',2,'Per.03','','PlateSearch','',14.81,'Pass'],
    [1,'Search Default: without Plate Number + default others filter',6,'Per.10','','PlateSearch','',21.82,'Pass'],
    [1,'Search Default: without Plate Number + default others filter',0,'Per.01','','PlateSearch','',20.84,'Pass'],
    [1,'Search Default: without Plate Number + default others filter',3,'Per.05','','PlateSearch','',30.27,'Pass'],
    [2,'Search Default: Plate Number + default others filter',8,'Per.02','','PlateSearch','',4.13,'Pass'],
    [2,'Search Default: Plate Number + default others filter',9,'Per.03','','PlateSearch','',5.35,'Pass'],
    [2,'Search Default: Plate Number + default others filter',12,'Per.09','','PlateSearch','',4.42,'Pass'],
    [2,'Search Default: Plate Number + default others filter',11,'Per.08','','PlateSearch','',4.37,'Pass'],
    [2,'Search Default: Plate Number + default others filter',13,'Per.10','','PlateSearch','',4.57,'Pass'],
    [2,'Search Default: Plate Number + default others filter',7,'Per.01','','PlateSearch','',5.07,'Pass'],
    [2,'Search Default: Plate Number + default others filter',10,'Per.05','','PlateSearch','',4.57,'Pass'],
    [3,'Search Default: MultiPlate + default others filter',14,'Per.01','','PlateSearch','',4.64,'Pass'],
    [3,'Search Default: MultiPlate + default others filter',15,'Per.02','','PlateSearch','',4.67,'Pass'],
    [3,'Search Default: MultiPlate + default others filter',16,'Per.03','','PlateSearch','',5.74,'Pass'],
    [3,'Search Default: MultiPlate + default others filter',18,'Per.08','','PlateSearch','',4.77,'Pass'],
    [3,'Search Default: MultiPlate + default others filter',19,'Per.09','','PlateSearch','',5.59,'Pass'],
    [3,'Search Default: MultiPlate + default others filter',17,'Per.05','','PlateSearch','',6.55,'Pass'],
    [3,'Search Default: MultiPlate + default others filter',20,'Per.10','','PlateSearch','',4.99,'Pass'],
    [4,'Search Default: Common misread Plate Number + default others filter',21,'Per.01','','PlateSearch','',16.97,'Pass'],
    [4,'Search Default: Common misread Plate Number + default others filter',25,'Per.08','','PlateSearch','',4.61,'Pass'],
    [4,'Search Default: Common misread Plate Number + default others filter',22,'Per.02','','PlateSearch','',4.31,'Pass'],
    [4,'Search Default: Common misread Plate Number + default others filter',24,'Per.05','','PlateSearch','',4.57,'Pass'],
    [4,'Search Default: Common misread Plate Number + default others filter',26,'Per.09','','PlateSearch','',4.68,'Pass'],
    [4,'Search Default: Common misread Plate Number + default others filter',23,'Per.03','','PlateSearch','',4.38,'Pass'],
    [4,'Search Default: Common misread Plate Number + default others filter',27,'Per.10','','PlateSearch','',3.96,'Pass'],
    [5,'Search Plate + Date and time range',28,'Per.01','','PlateSearch','',2.88,'Pass'],
    [5,'Search Plate + Date and time range',29,'Per.02','','PlateSearch','',2.67,'Pass'],
    [5,'Search Plate + Date and time range',30,'Per.03','','PlateSearch','',2.89,'Pass'],
    [5,'Search Plate + Date and time range',31,'Per.05','','PlateSearch','',2.67,'Pass'],
    [5,'Search Plate + Date and time range',34,'Per.10','','PlateSearch','',2.75,'Pass'],
    [5,'Search Plate + Date and time range',32,'Per.08','','PlateSearch','',3.24,'Pass'],
    [5,'Search Plate + Date and time range',33,'Per.09','','PlateSearch','',3.09,'Pass'],
    [6,'Search Vehicle Type',35,'Per.01','','PlateSearch','',301.81,'Pass'],
    [6,'Search Vehicle Type',37,'Per.03','','PlateSearch','',302.06,'Pass'],
    [6,'Search Vehicle Type',36,'Per.02','','PlateSearch','',302.28,'Pass'],
    [6,'Search Vehicle Type',38,'Per.05','','PlateSearch','',301.9,'Pass'],
    [6,'Search Vehicle Type',40,'Per.09','','PlateSearch','',302.26,'Pass'],
    [6,'Search Vehicle Type',39,'Per.08','','PlateSearch','',302.31,'Pass'],
    [6,'Search Vehicle Type',41,'Per.10','','PlateSearch','',302.41,'Pass'],
    [7,'Search Make + Model',42,'Per.01','','PlateSearch','',302.02,'Pass'],
    [7,'Search Make + Model',43,'Per.02','','PlateSearch','',302,'Pass'],
    [7,'Search Make + Model',44,'Per.03','','PlateSearch','',301.91,'Pass'],
    [7,'Search Make + Model',45,'Per.05','','PlateSearch','',302.04,'Pass'],
    [7,'Search Make + Model',47,'Per.09','','PlateSearch','',301.9,'Pass'],
    [7,'Search Make + Model',46,'Per.08','','PlateSearch','',302,'Pass'],
    [7,'Search Make + Model',48,'Per.10','','PlateSearch','',301.99,'Pass'],
    [8,'Search Colors',49,'Per.01','','PlateSearch','',302.09,'Pass'],
    [8,'Search Colors',50,'Per.02','','PlateSearch','',302.06,'Pass'],
    [8,'Search Colors',51,'Per.03','','PlateSearch','',302.1,'Pass'],
    [8,'Search Colors',53,'Per.08','','PlateSearch','',302.06,'Pass'],
    [8,'Search Colors',54,'Per.09','','PlateSearch','',302.51,'Pass'],
    [8,'Search Colors',52,'Per.05','','PlateSearch','',302.29,'Pass'],
    [8,'Search Colors',55,'Per.10','','PlateSearch','',302.33,'Pass'],
    [9,'Search Registration State',56,'Per.01','','PlateSearch','',30.19,'Pass'],
    [9,'Search Registration State',57,'Per.02','','PlateSearch','',20.32,'Pass'],
    [9,'Search Registration State',60,'Per.08','','PlateSearch','',23.61,'Pass'],
    [9,'Search Registration State',58,'Per.03','','PlateSearch','',32.78,'Pass'],
    [9,'Search Registration State',59,'Per.05','','PlateSearch','',27.61,'Pass'],
    [9,'Search Registration State',61,'Per.09','','PlateSearch','',40.07,'Pass'],
    [9,'Search Registration State',62,'Per.10','','PlateSearch','',40.06,'Pass'],
    [10,'Search Location + Default',63,'Per.01','','PlateSearch','',304.39,'Pass'],
    [10,'Search Location + Default',64,'Per.02','','PlateSearch','',302.19,'Pass'],
    [10,'Search Location + Default',65,'Per.03','','PlateSearch','',302.09,'Pass'],
    [10,'Search Location + Default',66,'Per.05','','PlateSearch','',302.28,'Pass'],
    [10,'Search Location + Default',67,'Per.08','','PlateSearch','',302.33,'Pass'],
    [10,'Search Location + Default',69,'Per.10','','PlateSearch','',302.69,'Pass'],
    [10,'Search Location + Default',68,'Per.09','','PlateSearch','',302.57,'Pass'],
    [11,'Search State/County + Default',70,'Per.01','','PlateSearch','',301.79,'Pass'],
    [11,'Search State/County + Default',71,'Per.02','','PlateSearch','',302.03,'Pass'],
    [11,'Search State/County + Default',72,'Per.03','','PlateSearch','',301.92,'Pass'],
    [11,'Search State/County + Default',73,'Per.05','','PlateSearch','',301.86,'Pass'],
    [11,'Search State/County + Default',76,'Per.10','','PlateSearch','',302.51,'Pass'],
    [11,'Search State/County + Default',74,'Per.08','','PlateSearch','',302.06,'Pass'],
    [11,'Search State/County + Default',75,'Per.09','','PlateSearch','',302.71,'Pass'],
    [12,'Search Plate Number + Make',77,'Per.01','','PlateSearch','',302.37,'Pass'],
    [12,'Search Plate Number + Make',78,'Per.02','','PlateSearch','',302.18,'Pass'],
    [12,'Search Plate Number + Make',79,'Per.03','','PlateSearch','',302.24,'Pass'],
    [12,'Search Plate Number + Make',80,'Per.05','','PlateSearch','',302.4,'Pass'],
    [12,'Search Plate Number + Make',81,'Per.08','','PlateSearch','',302.61,'Pass'],
    [12,'Search Plate Number + Make',83,'Per.10','','PlateSearch','',303.77,'Pass'],
    [12,'Search Plate Number + Make',82,'Per.09','','PlateSearch','',303.53,'Pass'],
];

// Sample test data matching the format from temp/input.jpg
const TEST_RAW = [
    [null, 'VM80.Prod.270 [2026-06-01_1400] Per.01', 'VM80.Prod.272 [2026-06-02_1400] Per.01', 'VM80.Prod.272 [2026-06-02_1700] Per.01'],
    ['Test Case Descriptions', null, null, null],
    ['Case 1', 55.93, 8.24, 9.08],
    ['Case 2', 7.43, 8.37, 3.38],
    ['Case 3', 23.96, 22.49, 4.43],
    ['Case 4', 9.29, 4.9, 115.0],
    ['Case 5', 4.45, 2.78, 4.94],
    ['Case 6', 301.7, 301.67, 301.93],
    ['Case 7', 301.54, 301.69, 301.73],
    ['Case 8', 301.47, 301.61, 301.7],
    ['Case 9', 34.23, 34.21, 25.84],
    ['Case 10', 301.74, 301.61, 301.84],
    ['Case 11', 301.51, 302.46, 300.2],
    ['Case 12', 301.63, 301.97, 359.36],
    ['Case 13', 8.31, 3.04, 8.09],
    ['Case 14', 204.56, 301.83, 164.62],
    ['Case 15', 17.73, 4.22, 44.87],
    ['Case 16', 8.99, 7.34, 99.0],
    ['Case 17', 420.61, 302.73, 301.73],
    ['Case 18', 62.79, 190.26, 91.83],
    ['Case 19', 301.54, 301.89, 301.74],
    ['Case 20', 3.21, 3.24, 4.93],
    ['Case 21', 146.91, 111.72, 240.5],
    ['Case 22', 21.44, 19.66, 23.93],
    ['Case 23', 5.61, 8.25, 9.39],
    ['Case 24', 5.85, 5.46, 10.47],
    ['Case 25', 3.91, 19.69, 5.73],
    ['Case 26', 2.31, 3.59, 2.84],
    ['Case 27', 2.42, 4.07, 2.44],
    ['Case 28', 3.94, 2.95, 3.17],
    ['Case 29', 2.95, 3.01, 8.09],
];

console.log('Launching app…');
const app = await electron.launch({
    executablePath: electronBin,
    args: [APP_DIR],
    timeout: 30_000,
});

await new Promise(r => setTimeout(r, 3000));
const page = app.windows().find(w => !w.url().startsWith('devtools://')) ?? await app.firstWindow();

// Screenshot 1: empty state
await page.screenshot({ path: path.join(SHOT_DIR, '01-empty.png') });
console.log('Screenshot 01-empty.png');

// Inject pivot-format test data
await page.evaluate(data => window._testLoad(data), TEST_RAW);
await new Promise(r => setTimeout(r, 1000));

// Screenshot 2: pivot chart loaded (default row height)
await page.screenshot({ path: path.join(SHOT_DIR, '02-chart-pivot.png') });
console.log('Screenshot 02-chart-pivot.png');

// Change row height to 48 and re-render
await page.evaluate(() => {
    const inp = document.getElementById('rowHeightInput');
    if (inp) { inp.value = '48'; inp.dispatchEvent(new Event('change')); }
});
await new Promise(r => setTimeout(r, 800));
await page.screenshot({ path: path.join(SHOT_DIR, '03-chart-rowH48.png') });
console.log('Screenshot 03-chart-rowH48.png');

// Inject flat-format test data
await page.evaluate(data => window._testLoad(data), FLAT_RAW);
await new Promise(r => setTimeout(r, 1000));
await page.screenshot({ path: path.join(SHOT_DIR, '04-chart-flat.png') });
console.log('Screenshot 04-chart-flat.png');

await app.close();
console.log('Done. Screenshots in:', SHOT_DIR);
