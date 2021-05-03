import {Query} from './query';
import {NotesModel, RoomModel} from '../../domain';
import {Database} from 'sqlite3';
import {Tables} from '../tables';

export class RoomQuery extends Query<RoomModel> {

    constructor(dbDriver: Database) {
        super(dbDriver, Tables.ROOMS);
    }

    async all(): Promise<RoomModel[]> {
        let rooms = await super.baseAll();
        return rooms.map(r => ({...r, notes: []}));
    }

    async get(id: number): Promise<RoomModel> {
        return new Promise(async (resolve, reject) => {
            let notes;
            const statement = this.dbDriver.prepare(`
                SELECT rooms.id,
                       rooms.roomName,
                       rooms.userId,
                       rooms.backgroundImage,
                       notes.id as noteId,
                       notes.note
                FROM rooms
                         LEFT JOIN notes ON rooms.id = notes.roomId
                WHERE rooms.id = ?;`);
            statement.all(id, function (err, queryResult) {
                if (err) reject(err);
                notes = queryResult.reduce((collection, next) => {
                    if (next.noteId != null) collection.push({
                        roomId: id,
                        note: next.note,
                        id: next.noteId
                    } as NotesModel)
                    return collection;
                }, []);
                resolve({
                    id: queryResult[0].id,
                    roomName: queryResult[0].roomName,
                    userId: queryResult[0].userId,
                    backgroundImage: queryResult[0].backgroundImage,
                    notes
                } as RoomModel)
            });
            statement.finalize(() => {})
        });
    }

    async update(model: RoomModel): Promise<boolean> {
        return super.baseUpdate(model);
    }

    async delete(id: number) {
        return super.baseDelete(id);
    }

    async insert(model: RoomModel): Promise<boolean> {
        return super.baseInsert(model);
    }

}
