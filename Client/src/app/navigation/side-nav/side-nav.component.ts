import { Component, OnInit, OnDestroy, OnChanges, DoCheck } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { Group } from '../../models/group.model';
import { Rank } from '../../models/rank.model';
import { Profile } from '../../models/profile.model';
import { Debate } from '../../models/debate.model';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { parseTemplate } from '@angular/compiler';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnDestroy {
  public storeSubscription: Subscription;
  public group: Group;
  public rank: Rank;
  public profile: Profile;
  public createdDebates: Debate[];
  public participatingDebates: Debate[];
  public currentItem: string;

  constructor(private store: Store<any>, private router: Router) {
    this.storeSubscription = store.subscribe(res => {
      this.group = res.group.group;
      this.rank = res.group.rank;
      this.profile = res.profile;
      this.createdDebates = res.debate.createdDebates;
      this.participatingDebates = res.debate.participatingDebates;
    });
    // get the GUID of the current item for selection purposes in nav
    router.events
      .pipe(filter(e => e instanceof NavigationEnd))
      .subscribe((res: any) => {
        if (res.url.includes('debate')) {
          this.currentItem = res.url.slice('/debate/'.length);
        } else if (res.url.includes('profile')) {
          this.currentItem = 'profile';
        } else if (res.url.includes('group')) {
          this.currentItem = res.url.slice('/group/'.length);
        } else {
          this.currentItem = '';
        }
      });
  }

  ngOnDestroy() {
    this.storeSubscription.unsubscribe();
  }
}
