import { Component, OnInit } from '@angular/core';
import { Tickets } from '../../models/tickets';
import { GetallticketsService } from '../../services/getalltickets.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  tickets: Tickets[] = [];
  constructor(
    private ticketsSrv: GetallticketsService,
    private router: Router
    ) {}

  ngOnInit() {
    this.ticketsSrv.getAllTickets().subscribe(result => (this.tickets = result), err => console.error(err));
  }

  goToTicket(id) {
    this.router.navigate(['tickets', id]);
    this.router.navigateByUrl('tickets/' + id);
  }
}
