import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from './main/auth/services/auth.service';
import { Store, Action, select } from '@ngrx/store';
import { AuthActions, Login, Logout } from './store/actions/auth.actions';
import { GroupActions, UpdateGroup } from './store/actions/group.actions';
import { ProfileActions, UpdateProfile } from './store/actions/profile.actions';
import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [
    trigger('openClose', [
      state('opened', style({
        transform: 'rotate(0deg)'
      })),
      state('closed', style({
        transform: 'rotate(180deg)'
      })),
      transition('opened => closed', [
        animate('200ms')
      ]),
      transition('closed => opened', [
        animate('200ms')
      ])
    ])
  ]
})
export class AppComponent implements OnInit, OnDestroy {
  public opened: boolean = false;
  public openingState: boolean = this.opened;
  public storeSubscription: Subscription;
  public authed$: Observable<boolean>;

  constructor(private store: Store<any>, private authService: AuthService) {
    this.storeSubscription = store.pipe(select('auth')).subscribe(res => this.authed$ = res);
  }

  ngOnInit() {
    this.authService.checkLogin().toPromise().then((res: any) => {
      this.store.dispatch(new Login());
      return res;
    })
    .then(res => {
      this.store.dispatch(new UpdateProfile(res.profile));
      return res;
    })
    .then(res => {
      this.store.dispatch(new UpdateGroup({ group: res.group, rank: res.rank }));
      return res;
    }).catch(err => {
      this.store.dispatch(null);
    });
  }

  setState() {
    if(this.authed$) {
      this.openingState = !this.openingState;
    } else {
      this.opened = false;
      this.openingState = false;
    }
  }

  ngOnDestroy() {
    this.storeSubscription.unsubscribe();
  }

}
