import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NgForm } from '@angular/forms';

export interface CommentData {
    text: string;
}

@Component({
    selector: 'comment-dialog',
    templateUrl: './comment-dialog.component.html'
})
export class CommentDialogComponent {
    public reply: string;
    constructor(public dialogRef: MatDialogRef<CommentDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: CommentData) { }

    onNoClick(): void {
        this.dialogRef.close();
    }

    submitReply(commentForm: NgForm) {
        console.log(commentForm.value);
    }
}