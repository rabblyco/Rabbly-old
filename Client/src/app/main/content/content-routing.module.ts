import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DebateComponent } from './debates/debate/debate.component';
import { GroupComponent } from './groups/groups/groups.component';
import { ProfileComponent } from './profiles/profile/profile.component';


const routes: Routes = [
  { path: 'group', component: GroupComponent },
  { path: 'group/:id', component: GroupComponent },
  { path: 'profile', component: ProfileComponent},
  { path: 'debate/:id', component: DebateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class ContentRoutingModule { }
