import { RightsService } from './../../../services/security/rights.service';
import { AccessRight } from './../../../models/security/accessRight';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-rights',
  templateUrl: './rights.component.html',
  styleUrls: ['./rights.component.css']
})
export class RightsComponent implements OnInit {
  rightsForm: FormGroup;
  rights: AccessRight[];
  errorMessage: string;
  constructor(private service: RightsService, private formBuilder: FormBuilder) {

   }

  ngOnInit() {
    this.rightsForm = this.formBuilder.group({
      rightName: ['']
  });
  }
  onSearchRights() {

    this.service.rightsGetRights(10, 1, this.rightsForm.get('rightName').value).subscribe(rights => {
      this.errorMessage = rights.message;
      this.rights = rights.accessRights; });
  }
}
