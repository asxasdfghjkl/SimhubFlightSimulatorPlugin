import { writeFileSync } from 'fs';

(async function run() {
    const rows = await loadSheet();
    writeFileSync("./rows.json", JSON.stringify(rows));
    console.log("Done!");
})()

import { GoogleSpreadsheet } from "google-spreadsheet";


async function loadSheet() {
    const doc = new GoogleSpreadsheet(
        "1Gan8iRlxc2CjrhcBaLeaWcCb1v9hGBj8IQDXrnkLjzE",
        { apiKey: import.meta.env.API_KEY, }
    );

    await doc.loadInfo(); // loads document properties and worksheets
    const sheet = doc.sheetsByIndex[0]; // or use `doc.sheetsById[id]` or `doc.sheetsByTitle[title]`
    return (await sheet.getRows()).map((row) => {
        const [groupName, simName, unit, type, simhubName] = row._rawData;
        return {
            groupName,
            simName,
            simhubName,
            unit,
            type,
            typeCs: toCsType(type),
            marshalAttr: toMarshalAttr(type)
        };
    });
}

function toCsType(type) {
    return {
        float32: "float",
        float64: "double",
        string8: "string",
        string32: "string",
        string64: "string",
        string128: "string",
        string256: "string",
        string260: "string",
        int32: "int",
        int64: "long",
    }[type];
}


function toMarshalAttr(type) {
    if (!type.startsWith("string")) return "";
    return `[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ${type.substring(
        "string".length
    )})]`;
}
