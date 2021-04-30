import {database} from './database';
import {environment, loadEnvironment} from '../utility';

describe('testing database.ts', () => {
    beforeEach(async () => {
        await loadEnvironment('environment.json')
        await database.init('');
    });

    afterEach(() => {
        database.close();
    })


    it('should return initialized true', () => {
        expect(database.initialized()).toBeTruthy();
    });

    it('should return one user', async (done) => {
        let users = database.users();
        await users.insert({username: 'Test User'});
        let u = await users.all();
        expect(u.length).toEqual(1);
        expect(u[0].username).toEqual('Test User');
        done();
    });




})
