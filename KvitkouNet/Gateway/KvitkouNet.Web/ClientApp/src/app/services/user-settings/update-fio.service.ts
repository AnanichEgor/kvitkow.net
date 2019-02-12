import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProfileModel } from '../../models/user-settings/update-fio';
@Injectable({
  providedIn: 'root'
})
export class UpdateFioService {
  private baseUrl = 'http://localhost:5009';
  constructor(private http: HttpClient) { }
}
