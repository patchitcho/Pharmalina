import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { ErrorHandlerService } from './errorHandler.service';
import { ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RoutingConfig } from './app-routing.module';

const eHandler = new ErrorHandlerService();

export function handler() {
    return eHandler; }

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [FormsModule,
    RoutingConfig, AuthModule, HttpClientModule,
    BrowserModule,
    AuthModule,
    AppRoutingModule
  ],
  providers: [
    { provide: ErrorHandlerService, useFactory: handler},
        { provide: ErrorHandler, useFactory: handler}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
