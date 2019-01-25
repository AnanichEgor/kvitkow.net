import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Tickets} from '../models/tickets';

@Injectable()
export class GetallticketsService {
  private baseUrl = 'http://localhost:58839';

  constructor(private http: HttpClient) {}

    getAllTickets() {
      return this.http.get<Tickets[]>(`${this.baseUrl}/api/tickets`);
  }

}
