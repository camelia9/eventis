﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../_models/user';
import { APP_CONSTANTS } from '../app.constants';

@Injectable()
export class UserService {
    constructor(private http: HttpClient) { }

  /*  getAll() {
        return this.http.get<User[]>(`${APP_CONSTANTS.ENDPOINT}/v1/Users/authenticate`);
    }

    getById(id: number) {
        return this.http.get('/api/users/' + id);
    }
*/
    create(user: User) {
        return this.http.post(`${APP_CONSTANTS.ENDPOINT}/api/userslog`, user);
    }
/*
    update(user: User) {
        return this.http.put('/api/users/' + user.id, user);
    }

    delete(id: number) {
        return this.http.delete('/api/users/' + id);
    }
    */
}
