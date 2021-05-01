import {Database} from 'sqlite3';
import {QueryableModel} from '../../types/queryable.model';

export abstract class Query<Model extends QueryableModel> {
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

    protected async baseUpdate(table: string, props: Model): Promise<boolean> {
        return new Promise((resolve, reject) => {
            let ins = this.generateInsertsForUpdate(props)
            let statement = this.dbDriver.prepare(
                `UPDATE ${table}
                 SET ${ins}
                 WHERE id = ${props.id}`
            );
            statement.run(function (err) {
                if (err) reject(false);
                resolve(true)
            });
        });
    }

    protected baseGet(table: string, id: number) {
        return new Promise((resolve, reject) => {
            let statement = this.dbDriver.prepare(`SELECT * FROM ${table} where id = ?`);
            statement.get(id, function (err, row) {
                if (err) reject(err);
                resolve(row)
            });
        });
    }

    protected baseDelete(table: string, id: number): Promise<boolean> {
        return new Promise((resolve, reject) => {
            let statement = this.dbDriver.prepare(`DELETE FROM ${table} where id = ?`);
            statement.run(id, (err) => {
                if(err) reject(err);
                resolve(true)
            })
        })
    }


    private generateInsertsForUpdate(props: Model): string {
        return Object.keys(props).reduce((a, k) => {
            if (k != 'id') {
                let s = typeof props[k] == 'string' ? `'${props[k]}'` : `${props[k]}`
                a.push(`${k} = ${s}`)
            }
            return a;
        }, []).join(", ");
    }

    abstract all(): Promise<Model[]>;

    abstract get(id: number): Promise<Model>;

    abstract update(model: Model): Promise<boolean>;

}
