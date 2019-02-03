import { SearchUserInfo } from "./../models/searchUserInfo";
import { SearchTicketInfo } from "./../models/searchTicketInfo";
import { SearchResult } from "./../models/searchResult";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { SearchTicket } from "../models/searchTicket";
import { SearchUser } from "../models/searchUser";

@Injectable({
  providedIn: "root"
})
export class SearchService {
  private baseUrl = "http://localhost:5008";

  constructor(private http: HttpClient) {}

  getTickets(request: SearchTicket) {
    return this.http.get<SearchResult<SearchTicketInfo>>(
      `${this.baseUrl}/api/search/tickets?${this.toQueryString(request)}`
    );
  }

  getUsers(request: SearchUser) {
    return this.http.get<SearchResult<SearchUserInfo>>(
      `${this.baseUrl}/api/search/users?${this.toQueryString(request)}`
    );
  }

  private toQueryString(obj) {
    return Object.keys(obj)
      .map(k => `${encodeURIComponent(k)}=${encodeURIComponent(obj[k])}`)
      .join("&");
  }
}
