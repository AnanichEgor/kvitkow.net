import { OAuthService } from 'angular-oauth2-oidc';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { News } from '../../models/dashboard/models';

@Injectable({ providedIn: 'root' })

export class DashboardService {
   private baseUrl = 'http://localhost:5009;';

  constructor(private http: HttpClient, private oauthService: OAuthService) {}

  getNews() {
    var headers = this.getHttpHeaders();
    return this.http.get<News[]>(`${this.baseUrl}/api/news`, {headers});
  }

  private getHttpHeaders(): HttpHeaders {
    var token = this.oauthService.getAccessToken();
    if (token != null) {
      return new HttpHeaders({
        "Authorization": "Bearer " + this.oauthService.getAccessToken()
      });
    }
    else {
      return new HttpHeaders();
    }
  }
}
