import { Injectable } from '@angular/core';
import {
    HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Logout } from 'src/app/store/actions/auth.actions';

export const InterceptorSkipHeader = 'X-Skip-Interceptor';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
    constructor(private router: Router, private store: Store<any>) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // Do not add Bearer token if it has this header value
        if (req.headers.has(InterceptorSkipHeader)) {
            const headers = req.headers.delete(InterceptorSkipHeader);
            return next.handle(req.clone({ headers }));
        }

        const token = localStorage.getItem('token');

        const authReq = req.clone({
            headers: req.headers.set('Authorization', 'Bearer ' + token)
        });

        return next.handle(authReq).pipe(catchError((err: HttpErrorResponse) => {
            if (err.status === 401) {
                this.store.dispatch(new Logout());
                this.router.navigate(['/auth/login']);
            } else {
                return throwError(err || '');
            }
        }));
    }
}
