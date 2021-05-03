import {environment, loadEnvironment} from './environment';


describe('ensure environment.json', () => {
    beforeAll(async () => {
        await loadEnvironment('environment.json');
    });

    it('Environment has been loaded', () => {
        expect(environment).toBeTruthy();
    });

    it('Environment has all required props', () => {
        let keys = Object.keys(environment);
        expect(keys.length).toBeGreaterThanOrEqual(6);
        expect(keys).toContain('connectString');
        expect(keys).toContain('encryptKey');
        expect(keys).toContain('port');
        expect(keys).toContain('development');
        expect(keys).toContain('inMemoryDB');
        expect(keys).toContain('uploadImagePath');
    });

    it('Expect error when environment not found', () => {
        const environmentPromise = loadEnvironment('bogus.json');
        environmentPromise.catch(() => {}) // suppress catch error
        expect(environmentPromise).rejects.toBeTruthy();
    });

    it('Expect no error when environment is found', () => {
        const environmentPromise = loadEnvironment('environment.json');
        expect(environmentPromise).resolves.toBeTruthy();
    });

})





