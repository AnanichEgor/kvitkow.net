import { Component, OnInit } from '@angular/core';
import { Tickets } from '../../models/tickets';
import { GetallticketsService } from '../../services/getalltickets.service';
import { ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  tickets: Tickets[] = [];
  constructor(private ticketsSrv: GetallticketsService, private route: ActivatedRoute) {
  }
  ngOnInit() {
    this.ticketsSrv.getAllTickets().subscribe(result => (this.tickets = result), err => console.error(err));
  }

  goToTicket(id) {

  }
}
