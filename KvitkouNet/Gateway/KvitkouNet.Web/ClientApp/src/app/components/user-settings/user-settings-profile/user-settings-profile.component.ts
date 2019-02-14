import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProfileModel } from 'src/app/models/user-settings/update-fio';

@Component({
  selector: 'app-user-settings-profile',
  templateUrl: './user-settings-profile.component.html',
  styleUrls: ['./user-settings-profile.component.css']
})
export class UserSettingsProfileComponent implements OnInit {
  profileModel: ProfileModel
  userSettingsProfile = new FormGroup({
    first: new FormControl(''),
    middle: new FormControl(''),
    last: new FormControl('')
  });
  constructor() { }

  ngOnInit() {
  }

}
