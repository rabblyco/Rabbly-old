import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DebateService } from '../services/debate.service';
import { Debate } from 'src/app/models/debate.model';

@Component({
  selector: 'app-debate',
  templateUrl: './debate.component.html',
  styleUrls: ['./debate.component.scss']
})
export class DebateComponent implements OnInit {
  public id: string;
  public debate: Debate;

  constructor(private route: ActivatedRoute, private debateService: DebateService) {
    this.route.paramMap.subscribe(params => {
      const previousId = this.id;
      this.id = params.get('id');
      if (this.id !== previousId) {
        this.debateService.getDebate(this.id).subscribe((res: any) => {
          this.debate = res;
        });
      }
    });
  }

  get editedAfterCreation(): boolean {
    if (this.debate) {
      return Date.parse(this.debate.updatedAt) > Date.parse(this.debate.createdAt);
    }
    return false;
  }

  ngOnInit() { }

}
