import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NgForm } from '@angular/forms';
import { ScoreCard } from 'src/app/models/scorecard.model';

export interface ScoreCardDialogData {
  commentText: string;
  scoreCard: ScoreCard;
}

@Component({
  selector: 'app-score-card',
  templateUrl: './score-card.component.html',
  styleUrls: ['./score-card.component.scss']
})
export class ScoreCardComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ScoreCardComponent>, @Inject(MAT_DIALOG_DATA) public data: ScoreCardDialogData) { }

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
}

  submitReply(scoreCardForm: NgForm) {
      console.log(scoreCardForm.value);
  }

  logIt(event) {
      console.log(event);
}

}
