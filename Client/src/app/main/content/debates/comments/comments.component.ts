import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input() comment: Comment;
  constructor() { }

  ngOnInit() {
  }

  log(event: MouseEvent, id: string) {
    console.log(id);
  }

}
