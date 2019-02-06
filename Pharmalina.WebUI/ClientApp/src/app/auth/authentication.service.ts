import { Injectable } from '@angular/core';
// import { Repository } from '../models/repository';
import { UsersClient, UserDto, SwaggerResponse, FileResponse } from '../shared/app.generated';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {

    authenticated = false;
    // name: string;
    // password: string;
    callbackUrl: string;
    user: UserDto;

    constructor(private repo: UsersClient,
                private router: Router) { }

        login(): Observable<boolean> {
        this.authenticated = false;
        const result = this.repo.authenticate(this.user).subscribe(Response => {
            if (Response.status === 200) {
                this.authenticated = true;
                this.router.navigateByUrl(this.callbackUrl || '/pages/products');
            } else { this.authenticated = false; }
        });
        return of(this.authenticated);
        // return this.repo.login(this.name, this.password)
           /* .subscribe(response => {
                if (response.result.status === 200) {
                    this.authenticated = true;
                    this.router.navigateByUrl(this.callbackUrl || '/admin/overview');
                }
                return this.authenticated;
            });*/
    }

    logout() {
        this.authenticated = false;
        // this.repo.logout();
        this.router.navigateByUrl('/login');
    }
}
