import { Component, OnInit } from '@angular/core';
import { UserSettings } from 'src/app/models/user-settings/userSettings';
import { AdvancedSettingsService } from 'src/app/services/user-settings/advanced-settings.service';


@Component({
  selector: 'app-user-settings-advanced',
  templateUrl: './user-settings-advanced.component.html',
  styleUrls: ['./user-settings-advanced.component.css']
})
export class UserSettingsAdvancedComponent implements OnInit {
  userSettings: UserSettings
  constructor(private advansedService: AdvancedSettingsService) { }

  ngOnInit() {
    this.advansedService.get(11).subscribe(err => {return console.error(err)});
  }
  onSubmit() {
    console.log(this.userSettings.PreferAddress);

    this.advansedService.get(11).subscribe(err => {return console.error(err)});

  }
}
