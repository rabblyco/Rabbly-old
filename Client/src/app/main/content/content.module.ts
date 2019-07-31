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

@NgModule({
  declarations: [DebateComponent, GroupComponent, ProfileComponent, DebatesComponent, DebateComponent, CommentsComponent],
  imports: [
    CommonModule,
    MomentModule
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
