import { TicketStatus } from './../../models/ticketStatus';
import { TypeEventTicket } from './../../models/typeEventTicket';
import { Address } from './../../models/address';
import { AddTicketService } from './../../services/add-ticket.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Ticket } from 'src/app/models/ticket';

@Component({
  selector: 'app-ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.css']
})
export class TicketFormComponent implements OnInit {
  addTicketForm: FormGroup;

  constructor(private ticketSrv: AddTicketService) {
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
      'additionalData' : new FormControl(),
      })
  }

  ngOnInit() {}

  onSubmit() {
    console.log(this.addTicketForm.value);
    //let body = JSON.stringify()
    this.ticketSrv.sendTicket(this.addTicketForm.value).subscribe(err => {return console.error(err)});
  }
}
