import { Component, OnInit } from '@angular/core';
import { UserSettings } from 'src/app/models/user-settings/userSettings';
import { AdvancedSettingsService } from 'src/app/services/user-settings/advanced-settings.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-user-settings-advanced',
  templateUrl: './user-settings-advanced.component.html',
  styleUrls: ['./user-settings-advanced.component.css']
})
export class UserSettingsAdvancedComponent implements OnInit {
  userSettingsModel: UserSettings
  private isPrivate: boolean;
  private isGetInfo: boolean;
  constructor(private advansedService: AdvancedSettingsService) { }

  ngOnInit() {
    this.advansedService.getSettings(11).subscribe(result=>(this.userSettingsModel = result, this.isPrivate = result.isPrivateAccount,
      this.isGetInfo = result.isGetTicketInfo), err => console.log(err));
    console.log(this.userSettingsModel)
  }
  onGet() {
    this.advansedService.putSettings(11, this.userSettingsModel).subscribe(err => console.log(err));
    console.log(this.userSettingsModel)
  }
  onPrivateChanged(value:boolean){
    this.userSettingsModel.isPrivateAccount = value;
  }
  onGetInfoChanged(value:boolean){
    this.userSettingsModel.isGetTicketInfo = value;
  }
}
