import { Action } from '@ngrx/store';
import { Profile } from '../../models/profile.model';

export enum ProfileActions {
    UpdateProfile = 'UPDATE_PROFILE'
}

export class UpdateProfile implements Action {
    readonly type = ProfileActions.UpdateProfile;

    constructor(public payload: { profile: Profile }) { }
}