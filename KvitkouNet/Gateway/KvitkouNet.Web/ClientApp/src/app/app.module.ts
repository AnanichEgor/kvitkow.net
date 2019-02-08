import { SecurityRoutingModule } from './components/security/security-routing.module';
import { SecurityMenuComponent } from './components/security/security-menu/security-menu.component';
import { UsersService } from './services/users.service';
import { EditGuard } from './services/editGuard';
import { GetallticketsService } from './services/getalltickets.service';
import { GetTicketByIdService } from './services/get-ticket-by-id.service';
import { LogService } from './services/log.service';
import { BrowserModule } from '@angular//platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MenuComponent } from './components/menu/menu.component';
import { FooterComponent } from './components/footer/footer.component';
import { AdminComponent } from './components/admin/admin.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { TicketFormComponent } from './components/ticket-form/ticket-form.component';
import { TicketDetailComponent} from './components/ticket-detail/ticket-detail.component';
import { UsersComponent } from './components/users/users.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { TicketEditComponent } from './components/ticket-edit/ticket-edit.component';
import { ChatComponent } from './components/chat/chat.component';
import { ErrorLogsComponent } from './components/admin/error-logs/error-logs.component';
import { AccountLogsComponent } from './components/admin/account-logs/account-logs.component';
import { PaymentLogsComponent } from './components/admin/payment-logs/payment-logs.component';
import { AdminMainComponent } from './components/admin/admin-main/admin-main.component';
import { SearchUserComponent } from './components/search-user/search-user.component';
import { SearchTicketComponent } from './components/search-ticket/search-ticket.component';
import { SearchTicketResultsComponent } from './components/search-ticket-results/search-ticket-results.component';
import { SearchUserResultsComponent } from './components/search-user-results/search-user-results.component';
import { SecurityModule } from './components/security/security.module';

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
    RegistrationComponent,
    TicketDetailComponent,
    TicketEditComponent,
    ChatComponent,
    SearchUserComponent,
    SearchTicketComponent,
    SearchTicketResultsComponent,
    SearchUserResultsComponent,
    AdminMainComponent,
    ErrorLogsComponent,
    AccountLogsComponent,
    PaymentLogsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    SecurityModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [GetTicketByIdService, GetallticketsService, EditGuard, LogService, UsersService, AppRoutingModule],
  bootstrap: [AppComponent]
})
export class AppModule {}
