import { Note } from './note.model';


export class Customer {
    id: string; // Guid
    status: CustomerStatus;
    createdDate: Date;
    name: string;
    contact: string;
    notes: Note[];

    // Extend props
    description: string;
}

export enum CustomerStatus {
    Prospective = 'Prospective',
    Current = 'Current',
    NonActive = 'NonActive',
}
