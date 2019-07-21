import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DebateComponent } from './debate/debate.component';
import { GroupComponent } from './groups/groups/groups.component';
import { ProfileComponent } from './profiles/profile/profile.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationInterceptor } from './authentication.interceptor';

@NgModule({
  declarations: [DebateComponent, GroupComponent, ProfileComponent],
  imports: [
    CommonModule
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
