import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ErrorLogEntry } from '../models/errorLogEntry';

@Injectable({
  providedIn: 'root'
})
export class LogService {
  private baseUrl = 'http://localhost:5005/';

  constructor(private http: HttpClient) {
      }

  getErrorLogs() {
    return this.http.get<ErrorLogEntry[]>(`${this.baseUrl}api/admin/logs/errors?exceptionTypeName=12345`);
  }
}