import {Query} from './query';
import {Database} from 'sqlite3';
import {NotesModel} from '../../domain';
import {Tables} from '../tables';

export class NoteQuery extends Query<NotesModel> {
    constructor(dbDriver: Database) {
        super(dbDriver, Tables.NOTES);
    }

    async all(): Promise<NotesModel[]> {
        return this.baseAll();
    }

    async get(id: number): Promise<NotesModel> {
        return super.baseGet(id)
    }

    async update(model: NotesModel): Promise<boolean> {
        return super.baseUpdate(model);
    }

    async delete(id: number) {
        return super.baseDelete(id)
    }

    async insert(model: NotesModel): Promise<boolean> {
        return this.baseInsert(model);
    }

}
