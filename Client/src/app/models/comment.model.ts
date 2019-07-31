interface Comment {
    id: string;
    text: string;
    debateId: string;
    createdById: string;
    parentComment: string;
    children: Comment[];
    scoreCard: any;
    updatedAt: Date;
    createdAt: Date;
}
