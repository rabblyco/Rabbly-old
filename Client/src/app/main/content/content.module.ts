import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DebateComponent } from './debates/debate/debate.component';
import { GroupComponent } from './groups/groups/groups.component';
import { ProfileComponent } from './profiles/profile/profile.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationInterceptor } from './authentication.interceptor';
import { DebatesComponent } from './debates/debates/debates.component';
import { CommentsComponent } from './debates/comments/comments.component';
import { MomentModule } from 'ngx-moment';
import { CommentDialogComponent } from "./debates/comments/comment-dialog/comment-dialog.component";
import { MatDialogModule } from '@angular/material';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [DebateComponent, GroupComponent, ProfileComponent, DebatesComponent, DebateComponent, CommentsComponent, CommentDialogComponent],
  imports: [
    CommonModule,
    MomentModule,
    MatDialogModule,
    FormsModule
  ],
  entryComponents: [
    CommentDialogComponent
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi: true
    }
  ]
})
export class ContentModule { }
