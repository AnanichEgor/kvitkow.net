import { VisibleSettings } from './visible';
import { NotificationSettings } from './notifications';

export class UserSettings {
    isGetTicketInfo: boolean;
    isPrivateAccount: boolean;
    notifications: NotificationSettings;
    preferAddress: string;
    preferRegion: string;
    preferPlace: string;
    settingsId: string;
    userImage?: null;   
    visibleInfo: VisibleSettings;
}
