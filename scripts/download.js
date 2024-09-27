import { writeFileSync } from 'fs';
import { loadSheet } from './loadSheet';

(async function run() {
    const rows = await loadSheet();
    writeFileSync("./rows.json", JSON.stringify(rows));
    console.log("Done!");
})()