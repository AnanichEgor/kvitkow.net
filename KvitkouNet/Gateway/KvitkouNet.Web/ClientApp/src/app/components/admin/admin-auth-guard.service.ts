import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, CanActivateChild } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable()
export class AdminAuthGuard implements CanActivate, CanActivateChild {

  constructor(private oauthService: OAuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.oauthService.getAccessToken() != null) {
      return true;
    }

    this.router.navigate(['/login']);
    return false;
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.oauthService.getAccessToken() != null) {
      return true;
    }

    this.router.navigate(['/login']);
    return false;
  }
}