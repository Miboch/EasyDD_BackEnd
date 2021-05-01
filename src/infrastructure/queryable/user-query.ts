import {UserModel} from '../../types';
import {Query} from './query';
import {Database} from 'sqlite3';
import {Tables} from '../../types/tables';

export class UserQuery extends Query<UserModel> {
    constructor(dbDriver: Database) {
        super(dbDriver);
    }

    async insert(props: UserModel): Promise<any> {
        return await super.baseInsert(Tables.USERS, props)
    }

    async all(): Promise<UserModel[]> {
        return super.each(`SELECT * FROM ${Tables.USERS}`);
    }

    async update(user: UserModel): Promise<boolean> {
        return this.baseUpdate(Tables.USERS, user);
    }

    async get(id: number): Promise<UserModel> {
        return this.baseGet(Tables.USERS, id);
    }

    async delete(id: number): Promise<boolean> {
        return this.baseDelete(Tables.USERS, id);
    }

}
