import { Component } from '@angular/core';
import { AccountService } from "../services/account service";
import { RegistrationModel } from "../models/registration.model";

@Component({
    selector: 'home-app',
    templateUrl: "registration.component.html",
    styleUrls: ["registration.component.less"]
})

export class RegistrationComponent {
    registrationModel!: RegistrationModel;
    errors!: string[];
    repeatPassword!: string;

    constructor(private accountService: AccountService) {
        this.registrationModel = { } as RegistrationModel;
    }

    register() : void {
        if(this.registrationModel.password !== this.repeatPassword)
            return;

        this.accountService.register(this.registrationModel).subscribe(x => {
                window.open('/#', '_self')
            },
            error => {
                if(error.status === 401 || error.status === 400) {
                    this.errors = error.error;
                }
            })
    }
}