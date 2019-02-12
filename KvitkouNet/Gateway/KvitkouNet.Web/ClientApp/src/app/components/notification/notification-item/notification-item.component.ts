import { UserNotification } from './../../../models/notification/userNotification';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/services/notification';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-notification-item',
  templateUrl: './notification-item.component.html',
  styleUrls: ['./notification-item.component.css']
})
export class NotificationItemComponent implements OnInit {

  public userNotifications: Array<UserNotification> = [];

  constructor(private service: NotificationService, private oauthService: OAuthService) {
    service.notificationGetAll().subscribe(data => this.userNotifications = data);
   }

  closeNotification(id: string) {
    this.service.notificationSetStatusClosed(id)
      .subscribe({complete: () => this.userNotifications = this.userNotifications.filter(x => x.notificationId !== id)});
  }

  ngOnInit() {
  }

  private getUserIdFromClaims() {
    const claims = this.oauthService.getIdentityClaims();
    if (claims) {
  }
    return claims['SubjectID'];
  }
}
