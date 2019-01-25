export class Tickets {
    id: string;
    user: [{
      userInfoId: string,
      firstName: string,
      lastName: string,
      rating: number
    }];
    respondedUsers: [
      {
        userInfoId: string,
        firstName: string,
        lastName: string,
        rating: number
      }
    ];
    free: boolean;
    name: string;
    locationEvent: [{
      country: string,
      city: string,
      street: string,
      house: string,
      flat: string
    }];
    price: number;
    additionalData: string;
    sellerPhone: string;
    sellerAdress: [{
      country: string,
      city: string,
      street: string,
      house: string,
      flat: string
    }];
    paymentSystems: string;
    timeActual: string;
    typeEvent: number;
    eventLink: string;
    status: number;
    createdDate: string;
}
