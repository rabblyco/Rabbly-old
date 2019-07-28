import { Action } from '@ngrx/store';
import { DebateActions, UpdateDebates } from '../actions/debate.actions';
import { Debate } from '../../models/debate.model';

const initialState = {};

export function debateReducer(state = initialState, action: UpdateDebates) {
    switch (action.type) {
        case DebateActions.UpdateDebates:
            return {
                ...state,
                createdDebates: action.payload.createdDebates,
                participatingDebates: action.payload.participatingDebates
            };
        default:
            return state;
    }
}