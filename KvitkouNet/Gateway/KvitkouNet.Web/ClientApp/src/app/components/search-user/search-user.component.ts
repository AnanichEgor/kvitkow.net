import { SearchUser } from "./../../models/searchUser";
import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
  selector: "app-search-user",
  templateUrl: "./search-user.component.html",
  styleUrls: ["./search-user.component.css"]
})
export class SearchUserComponent implements OnInit {
  searchUserForm = new FormGroup({
    rating: new FormControl("")
  });

  constructor(private router: Router) {}

  ngOnInit() {}

  onSubmit() {
    let request: SearchUser = Object.assign({}, this.searchUserForm.value);
    for (let key in request) {
      if (!request[key]) {
        delete request[key];
      }
    }

    this.router.navigate(["search-user-results", request]);
  }
}
