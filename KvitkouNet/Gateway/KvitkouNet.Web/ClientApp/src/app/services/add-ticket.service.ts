import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ticket } from '../models/ticket';


@Injectable({
  providedIn: 'root'
})
export class AddTicketService {


  private baseUrl = 'http://localhost:5007';

  constructor(private http: HttpClient) {}

    sendTicket(body){
      return this.http.post(`${this.baseUrl}/api/tickets`, body);
  }
}
