import { Component, OnInit } from '@angular/core';
import { EmailNotificationService, EmailNotification } from 'src/app/services/notification';

@Component({
  selector: 'app-email-notification-item',
  templateUrl: './email-notification-item.component.html',
  styleUrls: ['./email-notification-item.component.css']
})
export class EmailNotificationItemComponent implements OnInit {

  public emailNotifications: Array<EmailNotification>;

  constructor(private service: EmailNotificationService) {
    service.emailNotificationGetEmailNotifications('2323')
      .subscribe(data => this.emailNotifications = data);
   }

  ngOnInit() {
  }

}
