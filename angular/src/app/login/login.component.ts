import { Component } from '@angular/core';
import { AccountModel } from "../models/account.model";
import { AccountService } from "../services/account service";

@Component({
    selector: 'home-app',
    templateUrl: "login.component.html",
    styleUrls: ["login.component.less"]
})
export class LoginComponent {
    account!: AccountModel;
    errors!: string[];

    constructor(private accountService: AccountService) {
        this.account = { } as AccountModel;
    }

    signIn() : void {
        this.accountService.signIn(this.account).subscribe(x => {
            window.open('/#/battleField', '_self')
        },
        error => {
            if(error.status === 401 || error.status === 400) {
                this.errors = error.error;
            }
        })
    };
}