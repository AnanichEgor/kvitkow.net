import { Settings } from './../../models/chat/settings';
import { Observable } from 'rxjs';
import { Message } from './../../models/chat/message';
import { RoomService } from './../../services/chat/room.service';
import { ChatService } from './../../services/chat/chat.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { environment } from '../../../environments/environment';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  chatForm: FormGroup;
  messages: Message[];
  templateMessage: string;
  textFromMessage: string;
  userSettins: Settings;
  newMessage: Message;
  private connection: HubConnection;
  public messagesForHus: Array<Message> = [];
  authenticated: boolean;

  constructor(
    private serviceChat: ChatService, private serviceRoom: RoomService
    ) {
      this.authenticated = this.serviceChat.isAuthenticated();

      // установим соедениние для Hub
      this.connection = new HubConnectionBuilder()
      .withUrl(`${environment.searchServiceBaseUrl}/chat/notification`)
      .build();

      // Откроем Hub
      this.connection
      .start()
      .then(() => console.log('Connection established'))
      .catch(err => console.error(err));
      console.log('consrtructor');

// подпишемся на метод alertOnSendedMessageAllUsers на беке (показывает всем отправленое сообщение)
    this.connection.on('alertOnSendedMessageAllUsers', msg =>
    (console.log('startMethodHub. Came in method  = ' + msg.text ),
    this.newMessage = msg.text,
      this.messagesForHus.push(msg),
      console.log('EndMethodHub')
      ))
    ;      console.log('consrtructorEnd');
    console.log(this.newMessage);
     }

  ngOnInit() {
}

// Отправка сообщение
  onAddMessage(textMessage: string) {

     const message: Message = {
      text: textMessage,
      sendedTime: new Date(),
      isEdit: false,
      userId: '1'
    };
     this.serviceRoom.roomAddMessage(message, this.serviceChat.getUserIdFromClaims()).subscribe(
       (r) =>console.log(r)
     , err => console.log('err'));
  }

  // получение пользовательских настроек
  onGetUserSetting() {

     this.serviceChat.chatGetUserSettings('1').subscribe(x =>
      {

        this.userSettins = x;
      }
  );
  }

  // поиск сообщения по шаблону
  onSearchMessage(templateMessageIn: string){
    this.templateMessage = templateMessageIn;
    this.serviceRoom.roomSearchMessage('1', this.templateMessage).subscribe(x =>
      {
        this.messages = x;
      });
  }
}
