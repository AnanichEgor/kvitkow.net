import { GetTicketByIdService } from './../../services/get-ticket-by-id.service';
import { Component, OnInit } from '@angular/core';
import { Ticket } from '../../models/ticket';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-ticket-detail',
  templateUrl: './ticket-detail.component.html',
  styleUrls: ['./ticket-detail.component.css']
})
export class TicketDetailComponent implements OnInit {
  id: number;
  tickets: Ticket;
  authenticated: boolean;
  constructor(
    private ticketsSrv: GetTicketByIdService,
    private router: ActivatedRoute,
    private route: Router,
    private _location: Location
    ) {
      this.authenticated = this.ticketsSrv.isAuthenticated();
    router.params.subscribe(params => this.id = params.id);
    }

  ngOnInit() {
    this.ticketsSrv.getTicketById(this.id).subscribe(result => (this.tickets = result), err => console.error(err));
  }
  deleteTicketById(id) {
    this.ticketsSrv.delTicketById(id).subscribe(err => console.error(err));

  }
  backClicked() {
    this._location.back();
  }
}


