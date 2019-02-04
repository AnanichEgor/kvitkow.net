import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SecurityMenuComponent } from './security-menu/security-menu.component';
import { SecurityComponent } from './security.component';
import { NewRightComponent } from './new-right/new-right.component';
import { RightsComponent } from './rights/rights.component';

import { SecurityRoutingModule } from './security-routing.module';
import { FeaturesComponent } from './features/features.component';
import { NewFeatureComponent } from './new-feature/new-feature.component';
import { FunctionsComponent } from './functions/functions.component';
import { NewFunctionComponent } from './new-function/new-function.component';
import { RolesComponent } from './roles/roles.component';
import { NewRoleComponent } from './new-role/new-role.component';

@NgModule({
  declarations: [
    SecurityComponent,
    SecurityMenuComponent,
    NewRightComponent,
    RightsComponent,
    FeaturesComponent,
    NewFeatureComponent,
    FunctionsComponent,
    NewFunctionComponent,
    RolesComponent,
    NewRoleComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SecurityRoutingModule
  ]
})
export class SecurityModule { }
