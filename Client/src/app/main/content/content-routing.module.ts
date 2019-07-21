import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DebateComponent } from './debate/debate.component';
import { GroupComponent } from './groups/groups/groups.component';
import { ProfileComponent } from './profiles/profile/profile.component';


const routes: Routes = [
    { path: 'debate', component: DebateComponent },
    { path: 'group/:id', component: GroupComponent },
    { path: 'profile/:id', component: ProfileComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
