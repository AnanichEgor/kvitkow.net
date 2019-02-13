import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Ticket } from '../models/ticket';

@Injectable({
  providedIn: 'root'
})
export class GetallticketsService {
  private baseUrl = 'http://localhost:5007';

  constructor(private http: HttpClient, private oauthService: OAuthService) {}

  getSubId() {
    const claims: any = this.oauthService.getIdentityClaims();
    if (!claims) {
      return null;
    }
    console.log(claims.given_name);
   }
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
