import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ticket } from '../models/ticket';


@Injectable({
  providedIn: 'root'
})
export class GetTicketByIdService {

  private baseUrl = 'http://localhost:5007';

  constructor(private http: HttpClient) {}

  getTicketById(id) {
  return this.http.get<Ticket>(`${this.baseUrl}/api/tickets/${id}`);
}
delTicketById(id) {
  return this.http.delete(`${this.baseUrl}/api/tickets/${id}`);
}

}
