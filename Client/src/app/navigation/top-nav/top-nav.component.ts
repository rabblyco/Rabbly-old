import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { Logout } from 'src/app/store/actions/auth.actions';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.scss']
})
export class TopNavComponent implements OnDestroy {
  storeSubscription: Subscription;
  authed: boolean;

  constructor(private store: Store<any>, private router: Router) {
    this.storeSubscription = this.store.pipe(select('auth')).subscribe(res => {
      this.authed = res;
    });
  }

  public logout() {
    localStorage.removeItem('token');
    this.store.dispatch(new Logout());
    this.router.navigate(['/auth/login']);
  }

  ngOnDestroy(): void {
    this.storeSubscription.unsubscribe();
  }

}
