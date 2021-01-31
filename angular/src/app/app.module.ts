import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }   from './app.component';
import { AppRoutingModule } from './app-routing.module'
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { HttpClientModule } from "@angular/common/http";
import { HashLocationStrategy, LocationStrategy } from '@angular/common';


@NgModule({
    imports:      [
        BrowserModule,
        AppRoutingModule, ButtonsModule,
        BrowserAnimationsModule,
        InputsModule,
        HttpClientModule
    ],
    declarations: [ AppComponent],
    bootstrap:    [ AppComponent ],
    providers: [ { provide: LocationStrategy, useClass: HashLocationStrategy } ],
})
export class AppModule { }