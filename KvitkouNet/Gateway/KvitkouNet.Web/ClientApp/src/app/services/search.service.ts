import { SearchUserInfo } from './../models/searchUserInfo';
import { SearchTicketInfo } from './../models/searchTicketInfo';
import { SearchResult } from './../models/searchResult';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SearchTicket } from '../models/searchTicket';
import { SearchUser } from '../models/searchUser';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  private baseUrl = 'http://localhost:5008/api';

  constructor(private http: HttpClient) {}

  getTickets(request: SearchTicket) {
    return this.http.get<SearchResult<SearchTicketInfo>>(
      `${this.baseUrl}/search/tickets?${this.toQueryString(request)}`
    );
  }

  getUsers(request: SearchUser) {
    return this.http.get<SearchResult<SearchUserInfo>>(
      `${this.baseUrl}/search/users?${this.toQueryString(request)}`
    );
  }

  getPreviousTicketSearch(userId: String) {
    return this.http.get<SearchResult<SearchTicketInfo>>(
      `${this.baseUrl}/history/tickets?${this.toQueryString({usedId: userId})}`
    );
  }

  getPreviousUserSearch(userId: String) {
    return this.http.get<SearchResult<SearchUserInfo>>(
      `${this.baseUrl}/history/users?${this.toQueryString({usedId: userId})}`
    );
  }

  private toQueryString(obj) {
    return Object.keys(obj)
      .map(k => `${encodeURIComponent(k)}=${encodeURIComponent(obj[k])}`)
      .join('&');
  }
}
