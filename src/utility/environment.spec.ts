import {environment, loadEnvironment} from './environment';


beforeAll(async () => {
    await loadEnvironment('environment.json');
})

test('Environment has been loaded', () => {
    expect(environment).toBeTruthy();
});

test('Environment has all required props', () => {
    let keys = Object.keys(environment);
    expect(keys).toContain('connectString');
    expect(keys).toContain('encryptKey');
    expect(keys).toContain('port');
    expect(keys).toContain('development');
});

test('Expect error when environment not found', () => {
    const environmentPromise = loadEnvironment('bogus.json');
    environmentPromise.catch(() => {}) // suppress catch error
    expect(environmentPromise).rejects.toBeTruthy();
});

test('Expect no error when environment is found', () => {
    const environmentPromise = loadEnvironment('environment.json');
    expect(environmentPromise).resolves.toBeTruthy();
})
