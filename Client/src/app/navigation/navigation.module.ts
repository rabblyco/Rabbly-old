import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopNavComponent } from './top-nav/top-nav.component';
import { RouterModule } from '@angular/router';
import { SideNavComponent } from './side-nav/side-nav.component';

@NgModule({
  declarations: [TopNavComponent, SideNavComponent],
  imports: [
    CommonModule,
    RouterModule
  ],

  exports: [TopNavComponent, SideNavComponent]
})
export class NavigationModule { }
