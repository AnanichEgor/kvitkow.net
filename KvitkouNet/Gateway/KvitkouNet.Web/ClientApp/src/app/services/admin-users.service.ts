import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Users } from '../models/users';

@Injectable({
  providedIn: 'root'
})
export class AdminUsersService {
  private baseUrl = 'https://localhost:5002';
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<Users[]>(`${this.baseUrl}/admin/users`);
  }
}
