import { Address } from './../../models/address';
import { AddTicketService } from './../../services/add-ticket.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Ticket } from 'src/app/models/ticket';
import { Location } from '@angular/common';

@Component({
  selector: 'app-ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.css']
})
export class TicketFormComponent implements OnInit {
  addTicketForm: FormGroup;
  authenticated: boolean;

  constructor(private ticketSrv: AddTicketService, private _location: Location) {
    this.authenticated = this.ticketSrv.isAuthenticated();
    this.addTicketForm = new FormGroup({
      'name' : new FormControl(),
      'free' : new FormControl(),
      'locationEvent' : new FormGroup({
        'country' : new FormControl(),
        'city' : new FormControl(),
        'street' : new FormControl(),
        'house' : new FormControl(),
        'flat' : new FormControl(),
      }),
      'sellerAdress' : new FormGroup({
        'scountry' : new FormControl(),
        'scity' : new FormControl(),
        'sstreet' : new FormControl(),
        'shouse' : new FormControl(),
        'sflat' : new FormControl(),
      }),
      'additionalData' : new FormControl(),
      'typeEvent' : new FormControl(),
      })
  }

  ngOnInit() {}

  onSubmit() {
    console.log(this.addTicketForm.value);

    this.ticketSrv.sendTicket(this.addTicketForm.value).subscribe(err => {return console.error(err)});

  }
}
