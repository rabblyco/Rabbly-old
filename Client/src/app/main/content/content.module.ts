import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DebateComponent } from './debate/debate.component';
import { GroupComponent } from './groups/groups/groups.component';
import { ProfileComponent } from './profiles/profile/profile.component';

@NgModule({
  declarations: [DebateComponent, GroupComponent, ProfileComponent],
  imports: [
    CommonModule
  ]
})
export class ContentModule { }
