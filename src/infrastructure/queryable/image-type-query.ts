import {Query} from './query';
import {ImageTypesModel} from '../../domain';
import {Database} from 'sqlite3';
import {Tables} from '../tables';

export class ImageTypeQuery extends Query<ImageTypesModel> {

    constructor(dbConnection: Database) {
        super(dbConnection, Tables.IMAGE_TYPES);
    }

    async all(): Promise<ImageTypesModel[]> {
        return super.baseAll();
    }

    async delete(id: number) {
        return super.baseDelete(id);
    }

    async get(id: number): Promise<ImageTypesModel> {
        return super.baseGet(id);
    }

    async insert(model: ImageTypesModel): Promise<boolean> {
        return super.baseInsert(model);
    }

    async update(model: ImageTypesModel): Promise<boolean> {
        return super.baseUpdate(model);
    }

}
