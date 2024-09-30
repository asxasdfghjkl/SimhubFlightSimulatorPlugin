import { existsSync, readFileSync, readdirSync, unlinkSync, writeFileSync } from 'fs';
import Handlebars from "handlebars";
import { resolve } from 'path';
import { unique } from 'radash';
import './handlebar-setup';

const files = [
    {
        template: './outputs/simhub/TelemetryStates.template',
        output: ({ group }) => './../Plugin/TelemetryStates.cs',
    },
    {
        template: './outputs/server/Struct.template',
        prepare: () => {
            const dir = './../SimConnectServer/TelemetryData';
            const structs = readdirSync(dir).filter(path => !path.startsWith('_'));
            for (const file of structs) {
                unlinkSync(resolve(dir, file));
            }
        },
        getGroups: ({ rows }) => unique(rows.map(row => row.groupName)),
        getRows: ({ group, rows }) => rows.filter(row => row.groupName === group),
        output: ({ group }) => `./../SimConnectServer/TelemetryData/${group}.cs`,
    }
];

(async function run() {
    if (!existsSync("./rows.json")) {
        console.log("Please download the variables with the script first.");
        return exit(1);
    }
    const rows = JSON.parse(readFileSync("./rows.json", { encoding: 'utf-8' }));
    for (const file of files) {
        file.prepare?.();
        const templateFile = readFileSync(file.template, { encoding: 'utf-8' });
        const template = Handlebars.compile(templateFile, { noEscape: true });

        const groups = file.getGroups?.({ rows }) || ['1'];
        for (const group of groups) {
            if (!group) continue;
            const outputRows = file.getRows?.({ group, rows }) || rows;
            const result = template({ group, rows: outputRows });
            writeFileSync(file.output({ group }), result);
        }
    }
    console.log("Done!");
})()