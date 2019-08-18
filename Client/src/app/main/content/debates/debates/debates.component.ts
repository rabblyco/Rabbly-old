import { Component, OnInit } from '@angular/core';
import { DebateService } from '../services/debate.service';
import { Debate } from 'src/app/models/debate.model';

@Component({
  selector: 'app-debates',
  templateUrl: './debates.component.html',
  styleUrls: ['./debates.component.scss']
})
export class DebatesComponent implements OnInit {
  public debates: Debate[];

  constructor(private debateService: DebateService) { }

  ngOnInit() {
    this.debateService.getDebates().subscribe(res => this.debates = res);
  }

}
