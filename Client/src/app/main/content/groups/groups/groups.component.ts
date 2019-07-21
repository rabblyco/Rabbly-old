import { Component, OnInit } from '@angular/core';
import { GroupService } from '../services/group.service';
import { Group } from '../../../../models/group.model';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-group',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss']
})
export class GroupComponent implements OnInit {
  public group: Group;
  public id: string;

  constructor(private groupService: GroupService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(params => this.id = params.get('id'));
  }

  ngOnInit() {
    this.groupService.getGroup(this.id).subscribe(res => {
      this.group = res;
      console.log(this.group);
    });
  }

}
