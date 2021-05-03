import {Query} from './query';
import {TypesModel} from '../../domain';
import {Database} from 'sqlite3';
import {Tables} from '../tables';

export class TypeQuery extends Query<TypesModel> {

    constructor(dbConnection: Database) {
        super(dbConnection, Tables.TYPES);
    }

    async all(): Promise<TypesModel[]> {
        return super.baseAll();
    }

    async delete(id: number) {
        return super.baseDelete(id);
    }

    async get(id: number): Promise<TypesModel> {
        return super.baseGet(id);
    }

    async insert(model: TypesModel): Promise<boolean> {
        return super.baseInsert(model);
    }

    async update(model: TypesModel): Promise<boolean> {
        return super.baseUpdate(model);
    }
}
