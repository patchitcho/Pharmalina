import {Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { UsersClient } from '../../shared/app.generated';
import { from } from 'rxjs';

@Component({
    templateUrl: 'authentication.component.html'
})
export class AuthenticationComponent {

    constructor(public authService: AuthenticationService) {}

    showError = false;

    login() {
        this.showError = false;
        this.authService.login().subscribe(result => {
            this.showError = !result;
        });
    }
}
