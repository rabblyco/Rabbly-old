import { Action } from '@ngrx/store';
import { Group } from '../../models/group.model';
import { GroupActions, UpdateGroup } from '../actions/group.actions';

const initialState = {};

export function groupReducer(state = initialState, action: UpdateGroup) {
    switch (action.type) {
        case GroupActions.UpdateGroup:
            return {...state, group: action.payload.group, rank: action.payload.rank }
        default:
            return state;
    }
}