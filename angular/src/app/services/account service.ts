import {BaseService} from "./base/BaseService";
import {HttpClient} from "@angular/common/http";
import {AccountModel} from "../models/account.model";
import { Observable } from "rxjs";

export class AccountService extends BaseService {
    constructor(http: HttpClient) {
        super(http, "account");
    }

    signIn(account: AccountModel) : Observable<any> {
        return this.post("signIn", account);
    }
}