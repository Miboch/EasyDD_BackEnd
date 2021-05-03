import {NotesModel} from './notes.model';

export interface RoomModel {
    id?: number,
    roomName?: string,
    userId?: number,
    backgroundImage?: number;
    notes?: NotesModel[]
}
