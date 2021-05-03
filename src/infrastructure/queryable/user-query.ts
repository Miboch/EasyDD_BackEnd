import {Query} from './query';
import {Database} from 'sqlite3';
import {UserModel} from '../../domain';
import {Tables} from '../tables';

export class UserQuery extends Query<UserModel> {
    constructor(dbDriver: Database) {
        super(dbDriver, Tables.USERS);
    }

    async insert(props: UserModel): Promise<any> {
        return await super.baseInsert(props)
    }

    async all(): Promise<UserModel[]> {
        return super.baseAll();
    }

    async update(user: UserModel): Promise<boolean> {
        return super.baseUpdate(user);
    }

    async get(id: number): Promise<UserModel> {
        return super.baseGet(id);
    }

    async delete(id: number): Promise<boolean> {
        return super.baseDelete(id);
    }

}
