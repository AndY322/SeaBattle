import { NgModule }      from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { RouterModule, Routes } from "@angular/router";
import { RegistrationComponent } from './registration.component';

const routes: Routes = [
    { path: '', component: RegistrationComponent }
];

@NgModule({
    declarations: [ RegistrationComponent ],
    imports: [FormsModule, RouterModule.forChild(routes)]
})
export class RegistrationModule { }