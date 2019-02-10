import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../models/ticket';

@Injectable({
  providedIn: 'root'
})
export class GetallticketsService {
  private baseUrl = 'http://localhost:5007';

  constructor(private http: HttpClient) {}

    getAllTickets(id) {
      return this.http.get<Ticket[]>(`${this.baseUrl}/api/tickets/page/${id}`);
  }

}
