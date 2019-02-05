import { Rights } from './../../../services/security/operations/rights';
import { Security } from './../../../services/security/security';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-rights',
  templateUrl: './rights.component.html',
  styleUrls: ['./rights.component.css']
})
export class RightsComponent implements OnInit {
  rightsForm: FormGroup;
  constructor(private service: Security, private formBuilder: FormBuilder) {

   }

  ngOnInit() {
    this.rightsForm = this.formBuilder.group({
      rightName: ['']
  });
  }
  onSearchRights() {
    // this.service.rights.getRights(10, 1, this.rightsForm.get('rightName').value);
  }
}
