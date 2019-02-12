import { VisibleSettings } from './visible';
import { NotificationSettings } from './notifications';

export class UserSettings {
    First: string;
    Middle?: string;
    Last: string;
    Birthday: Date;
    UserImage?: string;
    IsPrivateAccount: boolean;
    IsGetTicketInfo: boolean;
    PreferAddress: string;
    PreferRegion: string;
    PreferPlace: string;
    Notifications: NotificationSettings;
    VidibleInfo: VisibleSettings;
}
