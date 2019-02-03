import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ErrorLogEntry } from '../models/errorLogEntry';
import { AccountLogEntry } from '../models/accountLogEntry';

@Injectable({
  providedIn: 'root'
})
export class LogService {
  private baseUrl = 'https://localhost:5002/';

  constructor(private http: HttpClient) {
      }

  getErrorLogs(queryParams : string) {
    return this.http.get<ErrorLogEntry[]>(`${this.baseUrl}admin/logs/errors?${queryParams}`);
  }

  getAccountLogs(queryParams : string) {
    return this.http.get<AccountLogEntry[]>(`${this.baseUrl}admin/logs/accounts?${queryParams}`);
  }
}
