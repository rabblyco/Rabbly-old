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

  get currentUserId(): string {
    const token = localStorage.getItem('token')
    const decodedToken = JSON.parse(atob(token.split('.')[1]));
    return decodedToken.sub;
  }

  get canEdit(): boolean {
    if(this.debate) {
      const isSameUser = this.debate.createdById === this.currentUserId;
      const createdLessThanAnHourAgo = (Date.now() - 1000 * 60 * 60) < new Date(this.debate.createdAt).getTime();
      if(isSameUser && createdLessThanAnHourAgo)
      {
        return true;
      }
      return false;
    }
    return false;
  }

  ngOnInit() {
    const token = localStorage.getItem('token')
    const decodedToken = JSON.parse(atob(token.split('.')[1]));
    console.log(decodedToken);
  }

}
