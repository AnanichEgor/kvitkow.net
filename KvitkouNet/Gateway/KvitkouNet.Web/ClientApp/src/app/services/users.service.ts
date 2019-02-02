import { Registration } from './../models/registration';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Users } from '../models/users';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private baseUrl = 'http://localhost:5003';

  constructor(private http: HttpClient) { }
  getUsers() {
    return this.http.get<Users[]>(`${this.baseUrl}/api/users`);
  }
}
