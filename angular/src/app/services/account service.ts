import {BaseService} from "./base/BaseService";
import {HttpClient} from "@angular/common/http";
import {AccountModel} from "../models/account.model";
import { Observable } from "rxjs";
import {RegistrationModel} from "../models/registration.model";

export class AccountService extends BaseService {
    constructor(http: HttpClient) {
        super(http, "account");
    }

    signIn(account: AccountModel) : Observable<any> {
        return this.post("signIn", account);
    }

    register(registrationModel: RegistrationModel) : Observable<any> {
        return this.post("register", registrationModel);
    }
}