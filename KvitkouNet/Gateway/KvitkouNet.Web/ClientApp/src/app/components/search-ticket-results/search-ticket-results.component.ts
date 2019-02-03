import { SearchService } from "./../../services/search.service";
import { SearchResult } from "./../../models/searchResult";
import { SearchTicket } from "./../../models/searchTicket";
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute, ParamMap } from "@angular/router";
import { switchMap, map, flatMap } from "rxjs/operators";
import { SearchTicketInfo } from "../../models/searchTicketInfo";
import { Observable } from "rxjs";

@Component({
  selector: "app-search-ticket-results",
  templateUrl: "./search-ticket-results.component.html",
  styleUrls: ["./search-ticket-results.component.css"]
})
export class SearchTicketResultsComponent implements OnInit {
  defaultLimit: number = 9;
  tickets: SearchResult<SearchTicketInfo> = new SearchResult<SearchTicketInfo>();
  request: SearchTicket = new SearchTicket({offset: 0, limit: this.defaultLimit});

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: SearchService
  ) {}

  ngOnInit() {
    let tickets$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        let request = this.getTicketRequest(params);
        let result = this.service.getTickets(request);
        return result.pipe(map(r => ({ request: request, result: r })));
      })
    );
    tickets$.subscribe(
      result => {
        this.request = result.request;
        this.tickets = result.result;
      },
      err => console.error(err)
    );
  }

  private getTicketRequest(params: ParamMap) {
    var request = new SearchTicket({
      limit: params.has("limit") ? parseInt(params.get("limit")) : this.defaultLimit,
      offset: params.has("offset") ? parseInt(params.get("offset")) : 0
    });

    setIfNotNull("name");
    setIfNotNull("category");
    setIfNotNull("city");
    setIfNotNull("dateFrom");
    setIfNotNull("dateTo");
    setIfNotNull("minPrice");
    setIfNotNull("maxPrice");

    return request;

    function setIfNotNull(name: string) {
      if (!!params.get(name)) {
        request[name] = params.get(name);
      }
    }
  }

  pageNumbers(count=0): number[] {
    return Array(Math.ceil(count / this.request.limit))
      .fill(0)
      .map((x, i) => i + 1);
  }

  isActive(pageNumber=0): boolean{
    let request = Object.assign({}, this.request);
    return (Math.ceil(request.offset / this.request.limit) == pageNumber-1);
  }

  goTo(pageNumber){
    let request = Object.assign({}, this.request);
    request.offset = (pageNumber - 1) * request.limit;
    this.router.navigate(['search-ticket-results', request]);
  }
}
