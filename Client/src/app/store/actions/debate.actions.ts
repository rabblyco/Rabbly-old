import { Action } from '@ngrx/store';
import { Debate } from '../../models/debate.model';

export enum DebateActions {
    UpdateDebates = 'UPDATE_DEBATES'
}

export class UpdateDebates implements Action {
    readonly type = DebateActions.UpdateDebates;

    constructor(public payload: { createdDebates: Debate[], participatingDebates: Debate[] }) { }
}
