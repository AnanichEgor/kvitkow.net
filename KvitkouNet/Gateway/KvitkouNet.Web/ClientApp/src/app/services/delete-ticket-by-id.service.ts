import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tickets } from '../models/tickets';

@Injectable({
  providedIn: 'root'
})
export class DeleteTicketByIdService {

  private baseUrl = 'http://localhost:58839';

  constructor(private http: HttpClient) {}
}
