import { TicketStatus } from './../../models/ticketStatus';
import { TypeEventTicket } from './../../models/typeEventTicket';
import { Address } from './../../models/address';
import { AddTicketService } from './../../services/add-ticket.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Ticket } from 'src/app/models/ticket';

@Component({
  selector: 'app-ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.css']
})
export class TicketFormComponent implements OnInit {
   ticket: Ticket;
   adress: Address;
   typeEventTicket: TypeEventTicket;
   ticketStatus: TicketStatus;

  constructor(
   private ticketSrv: AddTicketService,

  ) {   }

  ngOnInit() {
  }

  sendData(ticket: Ticket){

    this.ticketSrv.sendTicket(ticket).subscribe(err => {
      return console.error(err);
    });
  }
}
