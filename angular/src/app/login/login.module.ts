import { NgModule }      from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { LoginComponent }   from './login.component';
import { RouterModule, Routes } from "@angular/router";
import { ButtonModule } from "@progress/kendo-angular-buttons";
import { AccountService } from "../services/account service";
import { CommonModule } from "@angular/common";

const routes: Routes = [
    { path: '', component: LoginComponent }
];

@NgModule({
    declarations: [ LoginComponent ],
    imports: [ FormsModule, RouterModule.forChild(routes), ButtonModule, CommonModule ],
    providers: [ AccountService ]
})
export class LoginModule { }