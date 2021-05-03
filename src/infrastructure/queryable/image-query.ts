import {Query} from './query';
import {ImageModel, ImageTypesModel, TypesModel} from '../../domain';
import {Database} from 'sqlite3';
import {Tables} from '../tables';

export class ImageQuery extends Query<ImageModel> {

    constructor(dbConnection: Database) {
        super(dbConnection, Tables.IMAGES);
    }

    async all(): Promise<ImageModel[]> {
        const images = await super.baseAll();
        return images.map(i => ({...i, imageTypes: []}));
    }

    async delete(id: number) {
        return super.baseDelete(id);
    }

    async get(id: number): Promise<ImageModel> {
        return new Promise(async (resolve, reject) => {
            let imageTypes;
            const statement = this.dbDriver.prepare(`
                SELECT images.id,
                       images.imgPath,
                       images.userId,
                       images.imageName,
                       types.typeName,
                       imageTypes.id as imageTypeId
                FROM images
                         LEFT JOIN imageTypes ON images.id = imageTypes.imageId
                         LEFT JOIN types ON typeId = types.id
                WHERE images.id = ?
            `);

            statement.all(id, (err, result) => {
                if(err) reject(err);
                imageTypes = result.reduce((collection, next) => {
                    if(next.imageTypeId)
                        collection.push({
                            id: next.imageTypeId,
                            typeName: next.typeName
                        } as TypesModel);
                    return collection;
                }, []);
                resolve({
                    id: result[0].id,
                    imageName: result[0].imageName,
                    imgPath: result[0].imageName,
                    imageTypes,
                    userId: result[0].userId
                } as ImageModel);
            });
           statement.finalize(() => {});
        })

    }

    async insert(model: ImageModel): Promise<boolean> {
        return super.baseInsert(model);
    }

    async update(model: ImageModel): Promise<boolean> {
        return super.baseUpdate(model);
    }
}
