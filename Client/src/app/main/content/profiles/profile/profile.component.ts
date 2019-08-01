import { Component, OnInit } from '@angular/core';
import { Profile } from '../../../../models/profile.model';
import { ProfileService } from '../services/profile.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public profile: Profile;

  constructor(private profileService: ProfileService) { }

  ngOnInit() {
    this.profileService.getProfile().subscribe(res => this.profile = res);
  }

  public setStateDisplayValue(countryName: string) {
    if (countryName.includes('_')) {
      return countryName.replace(/_/gm, ' ');
    }
    return countryName;
  }

}
