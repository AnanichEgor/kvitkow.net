import { Address } from './address';

import { TicketStatus } from './ticketStatus';
import { TypeEventTicket } from './typeEventTicket';
import { TicketUserInfo } from './ticketUserInfo';

export interface Ticket {
    id?: string;
    user?: TicketUserInfo;
    respondedUsers?: Array<TicketUserInfo>;
    free: boolean;
    name?: string;
    locationEvent?: Address;
    price?: number;
    additionalData?: string;
    sellerPhone?: string;
    sellerAdress?: Address;
    paymentSystems?: string;
    timeActual: Date;
    typeEvent: TypeEventTicket;
    eventLink?: string;
    status: TicketStatus;
    createdDate: Date;
}
