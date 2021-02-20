import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AccountService } from '../service/account.service';
import { Router, NavigationExtras } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
// export class ErrorInterceptor implements HttpInterceptor {
//     constructor(private router: Router, private toastr: ToastrService) {}

//     intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//         return next.handle(req).pipe(
//             catchError(error => {
//                 if (error) {
//                     if (error.status === 400) {
//                         if (error.error.errors) {
//                             throw error.error;
//                         } else {
//                             this.toastr.error(error.error.message, error.error.statusCode);
//                         }
//                     }
//                     if (error.status === 401) {
//                         this.toastr.error(error.error.message, error.error.statusCode);
//                     }
//                     if (error.status === 404) {
//                         this.router.navigateByUrl('/not-found');
//                     }
//                     if (error.status === 500) {
//                         const navigationExtras: NavigationExtras = {state: {error: error.error}};
//                         this.router.navigateByUrl('/server-error', navigationExtras);
//                     }
//                 }
//                 return throwError(error);
//             })
//         );
//     }

// }
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private accountService: AccountService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if ([401, 403].includes(err.status) && this.accountService.accountValue) {
                // auto logout if 401 or 403 response returned from api
                this.accountService.logout();
            }

            const error = (err && err.error && err.error.message) || err.statusText;
            console.error(err);
            return throwError(error);
        }))
    }
}