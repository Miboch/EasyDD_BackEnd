import {TypesModel} from './types.model';

export interface ImageModel {
    id?: number,
    imgPath?: string,
    userId?: number,
    imageName?: string,
    imageTypes?: TypesModel[]
}
