import { Component, OnInit, Input, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CommentDialogComponent } from './comment-dialog/comment-dialog.component';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent {
  // tslint:disable-next-line: no-input-rename
  @Input() comment: Comment;
  constructor(public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(CommentDialogComponent, {
      data: { text: this.comment.text }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('closed');
    });
  }
}

