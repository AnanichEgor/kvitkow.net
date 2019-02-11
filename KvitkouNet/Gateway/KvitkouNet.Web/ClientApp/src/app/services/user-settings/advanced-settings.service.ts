import { UserSettings } from './../../models/user-settings/userSettings';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdvancedSettingsService {
  private baseUrl = 'http://localhost:5000';
  constructor(private http: HttpClient) { }
  get(id) {
    return this.http.get<UserSettings>(`${this.baseUrl}/api/settings/${id}`);
  }
}
