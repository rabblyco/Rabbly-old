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
import { CommentDialogComponent } from './debates/comments/comment-dialog/comment-dialog.component';
import { MatDialogModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { ContentRoutingModule } from './content-routing.module';
import { NotFoundComponent } from './misc/not-found/not-found.component';
import { HomeComponent } from './home/home.component';
import { QuillModule } from 'ngx-quill';
import { EditorComponent } from './debates/editor/editor.component';

@NgModule({
  declarations: [
    DebateComponent,
    GroupComponent,
    ProfileComponent,
    DebatesComponent,
    DebateComponent,
    CommentsComponent,
    CommentDialogComponent,
    NotFoundComponent,
    HomeComponent,
    EditorComponent
  ],
  imports: [
    CommonModule,
    ContentRoutingModule,
    MomentModule,
    MatDialogModule,
    FormsModule,
    QuillModule.forRoot({
      theme: 'snow'
    })
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
