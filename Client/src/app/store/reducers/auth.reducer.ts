import { Action } from '@ngrx/store';
import { AuthActions } from '../actions/auth.actions';

export const initialState = false;

export function authReducer(state = initialState, action: Action) {
    switch(action.type) {
        case AuthActions.Login:
            return true;
        case AuthActions.Logout:
            return false;
        default:
            return state;
    }
}