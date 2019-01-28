import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tickets } from '../models/tickets';


@Injectable({
  providedIn: 'root'
})
export class GetTicketByIdService {

  private baseUrl = 'http://localhost:58839';

  constructor(private http: HttpClient) {}

  getTicketById(id) {
  return this.http.get<Tickets>(`${this.baseUrl}/api/tickets/${id}`);
}
}


