import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { User } from '../models/user.model';
import { ApiUrls } from '../core'

@Injectable()
export class RegisterService {
    constructor(private http: Http) { }

    register(user: User) {
        let body = JSON.stringify(user);
        let registerUrl = ApiUrls.registerUrl;

        return <Observable<User>>this.http
            .post(registerUrl, body)
            .map((res: Response) => <User>res.json().data);
    }
}