import { Component, OnInit } from '@angular/core';
import { GroupService } from '../services/group.service';
import { Group } from '../../../../models/group.model';


@Component({
  selector: 'app-group',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss']
})
export class GroupComponent implements OnInit {
  public groups: Group[];

  constructor(private groupService: GroupService) {
    this.groupService.getGroups().subscribe(res => {
      this.groups = res;
      console.log(this.groups);
    });
  }

  ngOnInit() {
    // console.log(this.groups);
  }

}
