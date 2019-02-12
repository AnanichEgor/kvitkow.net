import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../models/ticket';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root'
})
export class GetallticketsService {
  private baseUrl = 'http://localhost:5007';

  constructor(private http: HttpClient, private oauthService: OAuthService) {}

  getAllTickets(id) {
    return this.http.get<Ticket[]>(`${this.baseUrl}/api/tickets/page/${id}`, {
      headers: this.getHeaders()
    });
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
