import {database} from './database';
import {environment, loadEnvironment} from '../utility';
import {doesNotThrow} from 'assert';

describe('testing database', () => {
    beforeEach(async () => {
        await loadEnvironment('environment.json');
        // forces inMemory for testing to prevent accidental inserts/deletes in actual db.
        environment.inMemoryDB = true;
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

    it('ROOMS should have NOTES', async (done) => {
        const rooms = database.rooms();
        const notes = database.notes();
        await rooms.insert({roomName: 'test room',})
        await rooms.insert({roomName: 'test room two',})
        await notes.insert({note: 'this is a simple note', roomId: 1});
        await notes.insert({note: 'this is also a note', roomId: 1});
        let r = await rooms.get(1);
        let r2 = await rooms.get(2);
        expect(r.notes.length).toEqual(2);
        expect(r.roomName).toEqual('test room');
        expect(r2.roomName).toEqual('test room two');
        expect(r2.notes.length).toEqual(0);
        done();
    })

    it('retrieving all rooms should have no notes', async (done) => {
        const rooms = database.rooms();
        const notes = database.notes();
        await rooms.insert({roomName: 'test room'})
        await rooms.insert({roomName: 'test room two'})
        await notes.insert({note: 'this is a simple note', roomId: 1});
        await notes.insert({note: 'this is also a note', roomId: 1});
        let r = await rooms.all();
        expect(r.length).toEqual(2);
        expect(r[0].notes.length).toEqual(0);
        done();
    });

    it('INSERT deletes the id prop to prevent accidental dupe keys', async (done) => {
        const rooms = database.rooms();
        const notes = database.notes();
        const users = database.users();
        const types = database.types();
        const image = database.image();
        const imageType = database.imageType();
        doesNotThrow(async () => {
            await rooms.insert({id: 1, roomName: "test"});
            await rooms.insert({id: 1, roomName: 'test 2'});
            await notes.insert({id: 1, roomId: 1});
            await notes.insert({id: 1, roomId: 1});
            await users.insert({id: 1, username: 'foo'});
            await users.insert({id: 1, username: 'bar'});
            await types.insert({id: 1, typeName: 'foo'});
            await types.insert({id: 1, typeName: 'bar'});
            await image.insert({id: 1, imageName: 'name'});
            await image.insert({id: 1, imageName: 'name two'});
            await imageType.insert({id: 1, imageId: 1, typeId: 1})
            await imageType.insert({id: 1, imageId: 1, typeId: 2})
            done();
        });
    });

    it('IMAGES should have types', async (done) => {
        const image = database.image();
        const type = database.types();
        const imageType = database.imageType();
        await image.insert({imageName: 'image one', imgPath: 'foo'});
        await image.insert({imageName: 'image two', imgPath: 'foo'});
        await type.insert({typeName: 'Background'});
        await type.insert({typeName: 'Token'});
        await imageType.insert({imageId: 1, typeId: 1});
        await imageType.insert({imageId: 1, typeId: 2});
        let i = await image.get(1);
        let i2 = await image.get(2);
        expect(i.imageTypes.length).toEqual(2);
        expect(i.imageTypes[0].typeName).toEqual('Background');
        expect(i2.imageTypes.length).toEqual(0);
        done();
    })


});
