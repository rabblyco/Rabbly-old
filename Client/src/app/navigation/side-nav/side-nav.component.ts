import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { Group } from '../../models/group.model';
import { Rank } from '../../models/rank.model';
import { Profile } from '../../models/profile.model';
import { Debate } from '../../models/debate.model';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit, OnDestroy {
  public storeSubscription: Subscription;
  public group: Group;
  public rank: Rank;
  public profile: Profile;
  public createdDebates: Debate[];
  public participatingDebates: Debate[];

  constructor(private store: Store<any>) {
    this.storeSubscription = store.subscribe(res => {
      this.group = res.group.group;
      this.rank = res.group.rank;
      this.profile = res.profile;
      this.createdDebates = res.debate.createdDebates;
      this.participatingDebates = res.debate.participatingDebates;
    });
  }

  ngOnInit() {}

  ngOnDestroy() {
    this.storeSubscription.unsubscribe();
  }
}
