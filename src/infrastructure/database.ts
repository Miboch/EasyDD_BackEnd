import {Database} from 'sqlite3';
import {environment} from '../utility';
import {UserQuery} from './queryable/user-query';
import {RoomQuery} from './queryable/room-query';
import {NoteQuery} from './queryable/note-query';
import {TypeQuery} from './queryable/type-query';
import {ImageQuery} from './queryable/image-query';
import {ImageTypeQuery} from './queryable/image-type-query';
import {Tables} from './tables';

const sqlite3 = require('sqlite3').verbose();
let isInitialized = false;
let dbDriver: Database;

export const database = {
    init: async (connectString: string) => {
        return new Promise<void>(async (res, rej) => {
            if(isInitialized) {
                res();
                return;
            }
            isInitialized = true;
            dbDriver = environment.inMemoryDB ? new sqlite3.Database(':memory:') : new sqlite3.Database(connectString);
            await ensureTablesCreated();
            res()
        });
    },
    users: () => new UserQuery(dbDriver),
    rooms: () => new RoomQuery(dbDriver),
    notes: () => new NoteQuery(dbDriver),
    types: () => new TypeQuery(dbDriver),
    image: () => new ImageQuery(dbDriver),
    imageType: () => new ImageTypeQuery(dbDriver),
    initialized: () => isInitialized,
    close: () => {
        dbDriver.close()
        isInitialized = false;
    }
}

async function ensureTablesCreated() {
    // we can use the generic run command on all query classes. Doesn't matter in particular that we use user.
    let tool = database.users();

    // USERS
    await tool.run(`CREATE TABLE IF NOT EXISTS ${Tables.USERS} (
        id INTEGER PRIMARY KEY AUTOINCREMENT, 
        username VARCHAR, 
        salt VARCHAR(20), 
        password VARCHAR
    )`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS users_name_index ON users(username)`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS users_id_index ON users(id)`);

    // TYPES
    await tool.run(`CREATE TABLE IF NOT EXISTS ${Tables.TYPES} (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        typeName VARCHAR
    )`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS types_id_index ON types(id)`);

    // IMAGES
    await tool.run(`CREATE TABLE IF NOT EXISTS ${Tables.IMAGES} (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        imgPath VARCHAR,
        userId INTEGER,
        imageName VARCHAR,
        FOREIGN KEY(userId) REFERENCES user(id)
    )`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS image_id_index ON images(id)`);

    // IMAGE_TYPES
    await tool.run(`CREATE TABLE IF NOT EXISTS ${Tables.IMAGE_TYPES} (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        imageId INTEGER,
        typeId INTEGER,
        FOREIGN KEY(imageId) REFERENCES image(id),
        FOREIGN KEY(typeId) REFERENCES types(id)
    )`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS image_types_id_index ON imageTypes(id)`);

    // ROOMS
    await tool.run(`CREATE TABLE IF NOT EXISTS ${Tables.ROOMS} (
        id INTEGER PRIMARY KEY AUTOINCREMENT, 
        roomName VARCHAR, 
        userid INTEGER, 
        backgroundImage INTEGER, 
        FOREIGN KEY(userid) REFERENCES user(id),
        FOREIGN KEY(backgroundImage) REFERENCES image(id)
        )`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS room_id_index ON rooms(id)`);

    // NOTES
    await tool.run(`CREATE TABLE IF NOT EXISTS ${Tables.NOTES}(
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        roomId INTEGER,
        note VARCHAR,
        FOREIGN KEY(roomId) REFERENCES rooms(id)
    )`);
    await tool.run(`CREATE UNIQUE INDEX IF NOT EXISTS room_id_index ON notes(id)`)
}

