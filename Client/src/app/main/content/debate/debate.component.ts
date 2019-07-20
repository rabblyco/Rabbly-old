import { Component, OnInit } from '@angular/core';
import { DebateService } from './services/debate.service';

@Component({
  selector: 'app-debate',
  templateUrl: './debate.component.html',
  styleUrls: ['./debate.component.scss']
})
export class DebateComponent implements OnInit {

  constructor(private debateService: DebateService) { }

  ngOnInit() {
    this.debateService.getDebates().subscribe(res => (
      console.log(res)
    ));
  }

}
