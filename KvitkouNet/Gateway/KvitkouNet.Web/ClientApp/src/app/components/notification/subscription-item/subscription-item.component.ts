import { Subscription } from './../../../models/notification/subscription';
import { Component, OnInit } from '@angular/core';
import { SubscriptionService } from 'src/app/services/notification';

@Component({
  selector: 'app-subscription-item',
  templateUrl: './subscription-item.component.html',
  styleUrls: ['./subscription-item.component.css']
})
export class SubscriptionItemComponent implements OnInit {

  public subscriptions: Array<Subscription> = [];

  constructor(private service: SubscriptionService) {
    service.subscriptionGetAll('2323')
      .subscribe(data => this.subscriptions = data);
   }

   closeSubscription(id: string, theme: string) {
    this.service.subscriptionUnsubscribe(id, theme)
      .subscribe({complete: () => this.subscriptions = this.subscriptions.filter(x => x.theme !== theme)});
  }

  ngOnInit() {
  }

}
