import { OAuthService } from 'angular-oauth2-oidc';
import { Address } from './../../models/address';
import { AddTicketService } from './../../services/add-ticket.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Ticket } from 'src/app/models/ticket';
import { Location } from '@angular/common';
import * as jwt_decode from "jwt-decode";
import { CanActivate } from '@angular/router/src/utils/preactivation';


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
      'eventLink' : new FormControl(),
      'additionalData' : new FormControl(),
      'typeEvent' : new FormControl(),
      'sellerPhone' : new FormControl(),
      'timeActual' : new FormControl(),
      'user' : new FormGroup({
      'userInfoId':   new FormControl(this.getUserId()),
      'firstName' : new FormControl(this.getUserName())
    }),
      });
  }

  ngOnInit() {}

  onSubmit() {
    console.log(this.addTicketForm.value);

    this.ticketSrv.sendTicket(this.addTicketForm.value).subscribe(err => {return console.error(err)});

  }

  getUserId(): string {
    var decodedToken = this.getDecodedAccessToken(this.oauthService.getAccessToken());
    return decodedToken['id'];

    }
    getUserName(): string {
      var decodedToken = this.getDecodedAccessToken(this.oauthService.getAccessToken());
      return decodedToken['name'];

      }


    getDecodedAccessToken(token: string): any {
      try{
          return jwt_decode(token);
      }
      catch(Error){
          return null;
      }
    }
}
