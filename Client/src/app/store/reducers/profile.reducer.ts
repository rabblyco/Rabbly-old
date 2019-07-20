import { Action } from '@ngrx/store';
import { Profile } from '../../models/profile.model';
import { ProfileActions, UpdateProfile } from '../actions/profile.actions';

const initialState = {};

export function profileReducer(state = initialState, action: UpdateProfile) {
    switch (action.type) {
        case ProfileActions.UpdateProfile:
            return action.payload;
        default:
            return state;
    }
}