import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule } from './auth/auth.module';
import { ContentModule } from './content/content.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AuthModule,
    ContentModule
  ]
})
export class MainModule { }
