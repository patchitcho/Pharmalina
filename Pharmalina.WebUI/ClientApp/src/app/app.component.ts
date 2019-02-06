import { Component } from '@angular/core';
import { ErrorHandlerService } from './errorHandler.service';
import { from } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Pharmalina';

  private lastError: string[];

    constructor(errorHandler: ErrorHandlerService) {
        errorHandler.errors.subscribe(error => {
            this.lastError = error;
        });
    }

    get error(): string[] {
        return this.lastError;
    }

    clearError() {
        this.lastError = null;
    }
}
