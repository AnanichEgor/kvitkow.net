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
  constructor(private advansedService: AdvancedSettingsService) { }

  ngOnInit() {
    this.advansedService.getSettings(11).subscribe(result=>(this.userSettingsModel = result), err => console.log(err));
  }
  onPut() {
    this.advansedService.putSettings(11, this.userSettingsModel).subscribe(err => console.log(err));
  }
  onPrivateChanged(value:boolean){
    this.userSettingsModel.isPrivateAccount = value;
  }
  onGetInfoChanged(value:boolean){
    this.userSettingsModel.isGetTicketInfo = value;
  }
}
