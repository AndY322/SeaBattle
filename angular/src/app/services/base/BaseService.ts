import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";

export class BaseService {
    constructor(private http: HttpClient, private controller: string) {}
    protected url = '/api';

    get(action?: string, params: HttpParams = new HttpParams()): Observable<any> {
        const options = {
            params: params,
        };
        return this.http
            .get(
                `${this.url}/${this.controller}/${action ? action : ""}`,
                options
            );
    }

    post(
        action?: string,
        body: Object = { },
        additionalOptions: Object = { }
    ): Observable<any> {
        if (additionalOptions) {
            return this.http
                .post(
                    `${this.url}/${this.controller}/${action ? action : ""}`,
                    body,
                    additionalOptions
                );
        } else {
            return this.http
                .post(
                    `${this.url}/${this.controller}/${action ? action : ""}`,
                    body
                );
        }
    }

    delete(
        action?: string,
        params: HttpParams = new HttpParams()
    ): Observable<any> {
        const options = {
            params: params,
        };
        return this.http
            .delete(`${this.url}/${this.controller}/${action ? action : ""}`, options);
    }
}