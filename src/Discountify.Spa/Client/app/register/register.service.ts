import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { User } from '../models/user.model';

@Injectable()
export class RegisterService {
    constructor(private http: Http) { }

    register(user: User) {
        let body = JSON.stringify(user);
        let userUrl = 'http://localhost:58059/api/auth/register';

        return <Observable<User>>this.http
            .post(userUrl, body)
            .map((res: Response) => <User>res.json().data);
    }
}