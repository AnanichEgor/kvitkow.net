import { RoomService } from './services/chat/room.service';
import { ChatService } from './services/chat/chat.service';
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
import { UserSettingsComponent } from './components/user-settings/user-settings.component';
import { QueryLogsComponent } from './components/admin/query-logs/query-logs.component';
import { TicketLogsComponent } from './components/admin/ticket-logs/ticket-logs.component';
import { DealLogsComponent } from './components/admin/deal-logs/deal-logs.component';
import { AdminUserComponent } from './components/admin/admin-user/admin-user.component';
import { UserSettingsProfileComponent } from './components/user-settings/user-settings-profile/user-settings-profile.component';
import { UserSettingsSecurityComponent } from './components/user-settings/user-settings-security/user-settings-security.component';
import { UserSettingsAdvancedComponent } from './components/user-settings/user-settings-advanced/user-settings-advanced.component';
import { SecurityModule } from './components/security/security.module';
import { OAuthModule } from 'angular-oauth2-oidc';
import { LoginComponent } from './components/login/login.component';

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
    AdminMainComponent,
    ErrorLogsComponent,
    AccountLogsComponent,
    PaymentLogsComponent,
    UserSettingsComponent,
    QueryLogsComponent,
    TicketLogsComponent,
    DealLogsComponent,
    AdminUserComponent,
    UserSettingsProfileComponent,
    UserSettingsSecurityComponent,
    UserSettingsAdvancedComponent,
    SearchUserResultsComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    SecurityModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    OAuthModule.forRoot()
  ],
  providers: [GetTicketByIdService, GetallticketsService, EditGuard, LogService, UsersService, ChatService, RoomService, AppRoutingModule],
  bootstrap: [AppComponent]
})
export class AppModule {}
