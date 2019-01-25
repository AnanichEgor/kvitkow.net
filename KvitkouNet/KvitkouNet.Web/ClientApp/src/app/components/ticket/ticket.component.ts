import { Component, OnInit } from '@angular/core';
import { Tickets } from '../../models/tickets' ;
import { GetallticketsService } from './../../services/getalltickets.service' ;

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
tickets: Tickets[] = [];

  constructor(private ticketsSrv: GetallticketsService) {

   }

  ngOnInit() {
    this.ticketsSrv.getAllTickets().subscribe(result => (this.tickets = result), err => console.error(err));
  }

}
