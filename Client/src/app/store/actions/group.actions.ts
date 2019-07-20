import { Group } from '../../models/group.model';
import { Rank } from '../../models/rank.model';
import { Action } from '@ngrx/store';

export enum GroupActions {
    UpdateGroup = 'UPDATE_GROUP'
}


export class UpdateGroup implements Action {
    readonly type = GroupActions.UpdateGroup;

    constructor(public payload: { group: Group, rank: Rank }) { }
}