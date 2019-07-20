import { Action } from '@ngrx/store'

export enum AuthActions {
    Login = 'LOGIN',
    Logout = 'LOGOUT',
}

export class Login implements Action {
    readonly type = AuthActions.Login;
}

export class Logout implements Action {
    readonly type = AuthActions.Logout;
}