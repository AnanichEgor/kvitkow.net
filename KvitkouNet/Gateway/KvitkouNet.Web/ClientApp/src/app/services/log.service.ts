import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ErrorLogEntry } from '../models/errorLogEntry';
import { AccountLogEntry } from '../models/accountLogEntry';
import { PaymentLogEntry } from '../models/paymentLogEntry';
import { QueryLogEntry } from '../models/queryLogEntry';
import { TicketLogEntry } from '../models/ticketLogEntry';
import { DealLogEntry } from '../models/dealLogEntry';

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

  getPaymentLogs(queryParams : string) {
    return this.http.get<PaymentLogEntry[]>(`${this.baseUrl}admin/logs/payments?${queryParams}`);
  }

  getQueryLogs(queryParams : string) {
      return this.http.get<QueryLogEntry[]>(`${this.baseUrl}admin/logs/queries?${queryParams}`);
  }

  getTicketLogs(queryParams : string) {
    return this.http.get<TicketLogEntry[]>(`${this.baseUrl}admin/logs/tickets?${queryParams}`);
  }

  getDealLogs(queryParams : string) {
    return this.http.get<DealLogEntry[]>(`${this.baseUrl}admin/logs/deals?${queryParams}`);
  }
}
