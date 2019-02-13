import { Registration } from './../../models/registration';
import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/users/users.service';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Location } from '@angular/common';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  registrationForm: FormGroup;
  er: string;

  constructor(private userSrv: UsersService, private _location: Location) {
  }

  ngOnInit() {
    this.registrationForm = new FormGroup({
      'username' : new FormControl('', [Validators.required, Validators.minLength(4)]),
      'email' : new FormControl('', [Validators.required, Validators.email]),
      'password' : new FormControl('', [Validators.required, Validators.minLength(6)]),
      'confirmpassword' : new FormControl('', [Validators.required])
     });
     this.registrationForm.valueChanges.subscribe(data => { console.log(data); this.er = data.toString(); });
     this.registrationForm.statusChanges.subscribe(data => console.log(data));
  }

  registry() {
    if (this.registrationForm.valid) {
    this.userSrv.sendUser(this.registrationForm.value).subscribe(err => { console.error(err); } );
    console.log('successfully registered');
    console.log(this.registrationForm.value);
    this._location.back();
    }
  }
}
