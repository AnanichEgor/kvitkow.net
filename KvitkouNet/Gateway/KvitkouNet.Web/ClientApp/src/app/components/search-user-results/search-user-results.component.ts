import { SearchUserInfo } from "./../../models/searchUserInfo";
import { SearchUser } from "./../../models/searchUser";
import { SearchService } from "./../../services/search.service";
import { SearchResult } from "./../../models/searchResult";
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute, ParamMap } from "@angular/router";
import { switchMap, map, flatMap } from "rxjs/operators";
import { Observable } from "rxjs";

@Component({
  selector: "app-search-user-results",
  templateUrl: "./search-user-results.component.html",
  styleUrls: ["./search-user-results.component.css"]
})
export class SearchUserResultsComponent implements OnInit {
  defaultLimit: number = 9;
  users: SearchResult<SearchUserInfo> = new SearchResult<SearchUserInfo>();
  request: SearchUser = new SearchUser({ offset: 0, limit: this.defaultLimit });

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: SearchService
  ) {}

  ngOnInit() {
    let users$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        let request = this.getUserRequest(params);
        let result = this.service.getUsers(request);
        return result.pipe(map(r => ({ request: request, result: r })));
      })
    );
    users$.subscribe(
      result => {
        this.request = result.request;
        this.users = result.result;
      },
      err => console.error(err)
    );
  }

  private getUserRequest(params: ParamMap) {
    var request = new SearchUser({
      limit: params.has("limit")
        ? parseInt(params.get("limit"))
        : this.defaultLimit,
      offset: params.has("offset") ? parseInt(params.get("offset")) : 0
    });

    setIfNotNull("rating");

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

  goTo(pageNumber) {
    let request = Object.assign({}, this.request);
    request.offset = (pageNumber - 1) * request.limit;
    this.router.navigate(["search-user-results", request]);
  }
}
