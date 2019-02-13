import { OAuthService } from 'angular-oauth2-oidc';
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

  constructor(private ticketSrv: AddTicketService, private _location: Location, private oauthService: OAuthService) {
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
        'country' : new FormControl(),
        'city' : new FormControl(),
        'street' : new FormControl(),
        'house' : new FormControl(),
        'flat' : new FormControl(),
      }),
      'additionalData' : new FormControl(),
      'typeEvent' : new FormControl(),
      'sellerPhone' : new FormControl(),
      'eventLink' : new FormControl()
      })
  }

  ngOnInit() {}

  public get userId() {
    const claims = this.oauthService.getIdentityClaims();
    if (!claims) { return null; }
    return claims;
}

  onSubmit() {
    console.log(this.addTicketForm.value);

    this.ticketSrv.sendTicket(this.addTicketForm.value).subscribe(err => {return console.error(err)});

  }
}
