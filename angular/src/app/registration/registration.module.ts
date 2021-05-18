import { NgModule }      from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { RouterModule, Routes } from "@angular/router";
import { RegistrationComponent } from './registration.component';
import { AccountService } from "../services/account service";
import { CommonModule } from "@angular/common";

const routes: Routes = [
    { path: '', component: RegistrationComponent }
];

@NgModule({
    declarations: [ RegistrationComponent ],
    imports: [FormsModule, RouterModule.forChild(routes), CommonModule],
    providers: [ AccountService ]
})
export class RegistrationModule { }