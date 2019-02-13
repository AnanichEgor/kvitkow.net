export class News {
  description: string;
  userInfo: [{
    userId: number;
    firstName: string;
    lastName: string;
  }];
  ticketInfo: [{
    name: string;
    locationEvent: string;
    price: number;
    sellerPhone: string;
    eventLink: string;
    timeActual: string;
  }];
  typeEvent: number;
  status: number;
  eventLink: string;
}
