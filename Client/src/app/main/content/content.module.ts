import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DebateComponent } from './debate/debate.component';
import { GroupComponent } from './groups/groups/groups.component';

@NgModule({
  declarations: [DebateComponent, GroupComponent],
  imports: [
    CommonModule
  ]
})
export class ContentModule { }
