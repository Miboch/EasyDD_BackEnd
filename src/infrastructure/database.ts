import {Database} from 'sqlite3';
import {environment} from '../utility';
import {UserQuery} from './queryable/user-query';

const sqlite3 = require('sqlite3').verbose();
let isInitialized = false;
let dbDriver: Database;


export const database = {
    init: async (connectString: string) => {
        if (isInitialized) return;
        isInitialized = true;
        dbDriver = environment.development ? new sqlite3.Database(':memory:') : new sqlite3.Database(connectString);
        await ensureTablesCreated()
    },
    users: () => new UserQuery(dbDriver),
    initialized: () => isInitialized,
    close: () => {
        dbDriver.close()
        isInitialized = false;
    }
}

async function ensureTablesCreated() {
    // we can use the generic run command on all query classes. Doesn't matter in particular that we use user.
    let tool = database.users();
    await tool.run(`CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, username VARCHAR, salt VARCHAR(20), password VARCHAR)`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS users_name_index ON users(username)`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS users_id_index ON users(id)`);

}

