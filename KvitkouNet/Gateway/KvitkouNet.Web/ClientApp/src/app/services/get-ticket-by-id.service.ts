import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tickets } from '../models/tickets';


@Injectable({
  providedIn: 'root'
})
export class GetTicketByIdService {

  private baseUrl = 'http://localhost:5000';

  constructor(private http: HttpClient) {}

  getTicketById(id) {
  return this.http.get<Tickets>(`${this.baseUrl}/api/tickets/${id}`);
}
delTicketById(id) {
  return this.http.delete(`${this.baseUrl}/api/tickets/${id}`);
}

}
