import { InjectionToken, Injector } from '@angular/core';

export const BASE_NOTIFICATION_PATH = new InjectionToken<string>('baseNotificationPath');
export const COLLECTION_FORMATS = {
    'csv': ',',
    'tsv': '   ',
    'ssv': ' ',
    'pipes': '|'
};

export const NotificationInjector: Injector =
  Injector.create({providers: [{provide: BASE_NOTIFICATION_PATH, useValue: 'http://localhost:5012/api'}]});
