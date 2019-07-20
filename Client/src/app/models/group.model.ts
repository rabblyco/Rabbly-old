import { Rank } from './rank.model';

export interface Group {
    id: string;
    logoUrl: string;
    name: string;
    bio: string;
    createdAt: string | Date;
    updatedAt: string | Date;
    rank: Rank;
}