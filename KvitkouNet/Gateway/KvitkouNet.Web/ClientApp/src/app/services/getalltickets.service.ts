import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tickets } from '../models/tickets';

@Injectable({
  providedIn: 'root'
})
export class GetallticketsService {
  private baseUrl = 'http://localhost:5000';

  constructor(private http: HttpClient) {}

    getAllTickets(id) {
      return this.http.get<Tickets[]>(`${this.baseUrl}/api/tickets/page/${id}`);
  }

}
