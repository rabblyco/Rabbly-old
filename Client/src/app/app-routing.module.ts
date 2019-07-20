import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './main/auth/login/login.component';
import { RegisterComponent } from './main/auth/register/register.component';
import { MainModule } from './main/main.module';
import { GroupComponent } from './main/content/groups/groups/groups.component';

const routes: Routes = [
  { path: 'group', component: GroupComponent },
  { path: 'group/:id', component: GroupComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
