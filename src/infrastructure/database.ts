let isInitialized = false;

export const database = {
    init: (connectString: string) => {
        isInitialized = true;
    },
    initialized: () => isInitialized
}
