import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './main/auth/auth.module';
import { ContentModule } from './main/content/content.module';
import { NavigationModule } from './navigation/navigation.module';
import { MatSidenavModule, } from '@angular/material';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

// reducers
import { authReducer } from './store/reducers/auth.reducer';
import { groupReducer } from './store/reducers/group.reducer';
import { profileReducer } from './store/reducers/profile.reducer';
import { debateReducer } from './store/reducers/debate.reducer';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AuthModule,
    ContentModule,
    NavigationModule,
    MatSidenavModule,
    AppRoutingModule,
    StoreModule.forRoot({ auth: authReducer, profile: profileReducer, group: groupReducer, debate: debateReducer }),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
