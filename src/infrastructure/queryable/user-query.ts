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

}
