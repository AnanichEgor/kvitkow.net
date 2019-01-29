import { EditGuard } from './services/editGuard';
import { GetallticketsService } from './services/getalltickets.service';
import { GetTicketByIdService } from './services/get-ticket-by-id.service';
import { BrowserModule } from '@angular//platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { FooterComponent } from './footer/footer.component';
import { AdminComponent } from './admin/admin.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { TicketFormComponent } from './components/ticket-form/ticket-form.component';
import { TicketDetailComponent} from './components/ticket-detail/ticket-detail.component';
import { UsersComponent } from './users/users.component';
import { RegistrationComponent } from './registration/registration.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { TicketEditComponent } from './components/ticket-edit/ticket-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    FooterComponent,
    AdminComponent,
    NotFoundComponent,
    TicketComponent,
    TicketFormComponent,
    UsersComponent,
    RegistrationComponent
    TicketDetailComponent,
    TicketEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [GetTicketByIdService, GetallticketsService, EditGuard],
  bootstrap: [AppComponent]
})
export class AppModule {}
