import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProfileModel } from '../../models/user-settings/update-fio';
import { Users } from 'src/app/models/users';
@Injectable({
  providedIn: 'root'
})
export class UpdateFioService {
  private baseUrl = 'http://localhost:5003';
  constructor(private http: HttpClient) { }

  getProfile(id) {
    return this.http.get<Users>(`${this.baseUrl}/api/users/${id}`);
  }
  
  putProfile(id, body) {
    return this.http.put(`${this.baseUrl}/api/users/${id}`, body)
  }
}
