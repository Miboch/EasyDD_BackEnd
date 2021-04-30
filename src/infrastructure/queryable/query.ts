import {Database} from 'sqlite3';

export abstract class Query<Model> {
    protected constructor(protected dbDriver: Database) {
    }

    run(query: string): Promise<any> {
        return new Promise((res, rej) => {
            this.dbDriver.run(query, function (this, err) {
                res(this);
            });
        });
    }

    protected async baseInsert<Model>(table: string, props: Model): Promise<any> {
        let inserts = `?,`.repeat(Object.keys(props).length);
        inserts = `(${inserts.slice(0, inserts.length - 1)})`;
        let statement = this.dbDriver.prepare(
            `INSERT INTO ${table} (${Object.keys(props).join(',')})
             VALUES ${inserts}`
        );

        return new Promise((resolve, reject) => {
            statement.run(...[Object.values(props)]);
            statement.finalize((error) => {
                if (error) reject(error)
                resolve(true);
            })
        });
    }


    protected async each(query: string): Promise<Model[]> {
        return new Promise((resolve, reject) => {
            const rows = [] as Model[];
            this.dbDriver.each(query,
                (error, row) => {
                    if (error) reject(error);
                    rows.push(row);
                },
                () => resolve(rows));
        });
    }

    abstract all(): Promise<Model[]>;


}
