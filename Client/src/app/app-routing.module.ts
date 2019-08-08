import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './main/auth/login/login.component';
import { RegisterComponent } from './main/auth/register/register.component';
import { MainModule } from './main/main.module';
import { GroupComponent } from './main/content/groups/groups/groups.component';
import { ProfileComponent } from './main/content/profiles/profile/profile.component';
import { DebateComponent } from './main/content/debates/debate/debate.component';
import { NotFoundComponent } from './main/content/misc/not-found/not-found.component';
import { HomeComponent } from './main/content/home/home.component';

const routes: Routes = [
  { path: 'not-found', component: NotFoundComponent },
  { path: '', component: HomeComponent },
  { path: '**', redirectTo: 'not-found' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
