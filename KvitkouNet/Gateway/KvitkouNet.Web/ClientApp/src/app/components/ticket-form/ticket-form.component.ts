import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.css']
})
export class TicketFormComponent implements OnInit {
  firstName: FormControl;
  lastName: FormControl;
  userFormGroup: FormGroup;
  id: number;

  constructor(private fb: FormBuilder) {
   }

  ngOnInit() {
    // this.FirstName = new FormControl ('Rodion');
     // this.FirstName.statusChanges.subscribe(data => console.log(data));

   // this.userFormGroup = new FormGroup({
   //   firstName: new FormControl('Ivan'),
   //   lastName: new FormControl('Ivanov')
   // });

   this.userFormGroup = this.fb.group({
     firstName: 'Ivan',
     lastName: 'Ivanov',
     addresses: this.fb.array([
       {
       street: '',
       city: '',
       building: ''

     }
    ])
    });

    this.userFormGroup.valueChanges.subscribe(data => console.log(data));
    this.userFormGroup.statusChanges.subscribe(data => console.log(data));

  }
  sendData() {
  console.log();
  }
}
