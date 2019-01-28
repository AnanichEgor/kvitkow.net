import { GetTicketByIdService } from './../../services/get-ticket-by-id.service';
import { Component, OnInit } from '@angular/core';
import { Tickets } from '../../models/tickets';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-ticket-detail',
  templateUrl: './ticket-detail.component.html',
  styleUrls: ['./ticket-detail.component.css']
})
export class TicketDetailComponent implements OnInit {
  id: number;
  tickets: Tickets;
  constructor(
    private ticketsSrv: GetTicketByIdService,
    private router: ActivatedRoute,
    private route: Router
    ) {
    router.params.subscribe(params => this.id = params.id);
    }

  ngOnInit() {
    this.ticketsSrv.getTicketById(this.id).subscribe(result => (this.tickets = result), err => console.error(err));
  }
  deleteTicketById(id) {
    this.ticketsSrv.delTicketById(id).subscribe(err => console.error(err));

  }
}


