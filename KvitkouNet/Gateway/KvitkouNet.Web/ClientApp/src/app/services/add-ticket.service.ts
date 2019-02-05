import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ticket } from '../models/ticket';


@Injectable({
  providedIn: 'root'
})
export class AddTicketService {


  private baseUrl = 'http://localhost:5007';

  constructor(private http: HttpClient) {}

    sendTicket(ticket: Ticket) {
      var body = {
        free: ticket.free,
        name: ticket.name,
        price: ticket.price,
        additionalData: ticket.additionalData,
        sellerPhone: ticket.sellerPhone,
        paymentSystems: ticket.paymentSystems,
        eventLink: ticket.eventLink,
        createdDate: Date.now
      };

      return this.http.post(`${this.baseUrl}/api/tickets`, body);
  }
}
