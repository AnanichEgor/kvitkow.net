import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private oauthService: OAuthService) {
  }

  ngOnInit(): void {
  }

  public logoff() {
      this.oauthService.logOut(true);
  }

  public get name() {
      const claims = this.oauthService.getIdentityClaims();
      if (!claims) { return null; }
      return claims['given_name'];
  }

  public isNeedToHideAdminPanel() : boolean{
    return !this.oauthService.hasValidAccessToken();
  }

}
