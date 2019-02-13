import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Ticket } from '../models/ticket';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root'
})
export class AddTicketService {
  private baseUrl = 'http://localhost:5007';

  constructor(private http: HttpClient, private oauthService: OAuthService) {}

  sendTicket(body) {
    return this.http.post(
      `${this.baseUrl}/api/tickets`,

      body,
      { headers: this.getHeaders() }
    );
  }
  isAuthenticated() {

    const token = this.oauthService.getAccessToken();
    return !!token ? true : false;
  }
  private getHeaders() {
    const token = this.oauthService.getAccessToken();
    return !!token
      ? new HttpHeaders({
          Authorization: 'Bearer ' + token
        })
      : new HttpHeaders();
  }
}
