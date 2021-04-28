import * as fs from 'fs';
import {EnvironmentModel} from '../types';

export let environment: EnvironmentModel;

export const loadEnvironment = (async (filename: string): Promise<EnvironmentModel> => {
    const envLoad = async (fileName: string) => {
        return new Promise(async (resolve, reject) => {
            if (!fs.existsSync(fileName)) reject({error: `file not found: ${fileName}`})
            fs.readFile(fileName, "utf8", (err, data) => {
                if (typeof data == 'undefined')
                    reject(err);
                else {
                    // remove invisible control-character from file before JSON.parse.
                    environment = JSON.parse(data.replace(/^\ufeff/g, ''));
                    resolve(environment);
                }
            })
        })
    }
    return envLoad(filename);
});
