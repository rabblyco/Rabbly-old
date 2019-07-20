import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DebateComponent } from './debate/debate.component';


const routes: Routes = [
    { path: 'debate', component: DebateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
