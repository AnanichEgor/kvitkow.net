import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Users } from 'src/app/models/users';
import { UpdateFioService } from 'src/app/services/user-settings/update-fio.service';
import { ForUpdateModel } from 'src/app/models/users/forUpdateModel';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-user-settings-profile',
  templateUrl: './user-settings-profile.component.html',
  styleUrls: ['./user-settings-profile.component.css']
})
export class UserSettingsProfileComponent implements OnInit {
  user: Users
  model: ForUpdateModel
  id: string = this.getUserId()
  userSettingsProfile = new FormGroup({
    first: new FormControl(''),
    middle: new FormControl(''),
    last: new FormControl('')
  });
  constructor(private updateFioService: UpdateFioService, private oauthService: OAuthService) { 
    this.id = this.getUserId();
  }

  ngOnInit() {
    
    console.log(this.id)
    this.updateFioService.getProfile(this.id).subscribe(result=>(this.user = result), err => console.log(err))
  }
  onPut(){
    this.model.firstName = this.user.firstName;
    this.model.lastName = this.user.firstName;
    this.model.birthday = this.user.birthday;
    this.updateFioService.putProfile(this.id, this.model).subscribe(err => console.log(err));
  }
  getUserId(): string {
    var decodedToken = this.getDecodedAccessToken(this.oauthService.getAccessToken());
    return decodedToken['id'];

    }
  getDecodedAccessToken(token: string): any {
     try{
        return jwt_decode(token);
    }
     catch(Error){
         return null;
     }
  }
}
