export interface Debate {
    id: string;
    topic: string;
    createdById: string;
    description: string;
    createdAt: string;
    updatedAt: string;
    comments: Comment[];
}
