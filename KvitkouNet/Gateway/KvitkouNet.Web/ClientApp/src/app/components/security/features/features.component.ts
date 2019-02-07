import { EditFeatureRequest } from './../../../models/security/editFeatureRequest';
import { RightsService } from 'src/app/services/security/rights.service';
import { AccessRight } from './../../../models/security/accessRight';
import { Feature } from './../../../models/security/feature';
import { FeatureService } from 'src/app/services/security/feature.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-features',
  templateUrl: './features.component.html',
  styleUrls: ['./features.component.css']
})
export class FeaturesComponent implements OnInit {
  featuresForm: FormGroup;
  features: Feature[];
  errorMessage: string;
  selectedFeature: Feature;
  selectedRight: AccessRight;
  rightsFound: AccessRight[];
  selectedAddRight: AccessRight;
  addPressed: boolean;
  constructor(private featureService: FeatureService, private rightsService: RightsService, private formBuilder: FormBuilder) {

   }

  ngOnInit() {
    this.featuresForm = this.formBuilder.group({
      featureName: [''],
      rightNameSearch: ['']
  });
  }
  onSearchFeatures() {
    this.featureService.featureGetFeatures(10, 1, this.featuresForm.get('featureName').value).subscribe(features => {
      this.errorMessage = features.message;
      this.features = features.features; });
  }
  onSelectFeature(feature: Feature) {
    this.selectedFeature = feature;
    this.addPressed = false;
    this.selectedAddRight = null;
  }
  onSelectRight(right: AccessRight) {
    this.selectedRight = right;
  }
  onAddRight() {
    this.addPressed = !this.addPressed;
  }
  onDeleteRight() {
    this.selectedFeature.availableAccessRights = this.selectedFeature.availableAccessRights
    .filter(right => right.id !== this.selectedRight.id);
    let request: EditFeatureRequest = {
      featureId: this.selectedFeature.id,
      rightsIds: this.selectedFeature.availableAccessRights.map(function(a) { return a.id; })
    };
    this.featureService.featureEditFeature(request).subscribe(features => {
      this.errorMessage = features.message; });
  }
  onAddedSearch() {
    console.log('"' + this.featuresForm.get('rightNameSearch').value + '"');
    this.rightsService.rightsGetRights(5, 1, this.featuresForm.get('rightNameSearch').value).subscribe(features => {
      this.errorMessage = features.message;
      this.rightsFound = features.accessRights;
      console.log(this.rightsFound); });
  }
  onAddRightSelected(right: AccessRight) {
    this.selectedAddRight = right;
    console.log(this.selectedAddRight);
  }
  onAddSelectedRight() {
    this.selectedFeature.availableAccessRights.push(this.selectedAddRight);
    let request: EditFeatureRequest = {
      featureId: this.selectedFeature.id,
      rightsIds: this.selectedFeature.availableAccessRights.map(function(a) { return a.id; })
    };
    this.featureService.featureEditFeature(request).subscribe(features => {
      this.errorMessage = features.message; });
    this.selectedAddRight = null;
  }
}
