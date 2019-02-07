import { SearchTicket } from './../../models/searchTicket';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-ticket',
  templateUrl: './search-ticket.component.html',
  styleUrls: ['./search-ticket.component.css']
})
export class SearchTicketComponent implements OnInit {
  searchTicketForm = new FormGroup({
    name: new FormControl(''),
    category: new FormControl(''),
    city: new FormControl(''),
    dateFrom: new FormControl(''),
    dateTo: new FormControl(''),
    minPrice: new FormControl(''),
    maxPrice: new FormControl('')
  });

  constructor(private router: Router) {}

  ngOnInit() {}

  onSubmit() {
    const request: SearchTicket = Object.assign({}, this.searchTicketForm.value);
    for (const key in request) {
      if (!request[key]) {
        delete request[key];
      }
    }

    this.router.navigate(['search-ticket-results', request]);
  }

  previousSearch() {
    const userId = this.router
  }
}
