import { Settings } from './../../models/chat/settings';
import { Observable } from 'rxjs';
import { Message } from './../../models/chat/message';
import { RoomService } from './../../services/chat/room.service';
import { ChatService } from './../../services/chat/chat.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';


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
      // прошел ли пользователь Authenticat
    //  this.authenticated = this.serviceChat.isAuthenticated();
      console.log('настраиваем коннект для Hub');
      // настроим коннект для Hub
      this.connection = new HubConnectionBuilder()
      .withUrl('https://localhost:5002/chat/notification')
      .build();

      this.connection
      .start()
      .then(() => console.log('Connection established'))
      .catch(err => console.error('ошибка коннекта'));

    // регистрируемся на метод alertOnSendedMessageAllUsers
    this.connection.on('alertOnSendedMessageAllUsers', msg =>
    (console.log('startMethodHub. Came in method  = ' + msg ),
      this.messagesForHus.push(msg),
      console.log('EndMethodHub')
      ));
     }

  ngOnInit() {
}

// отправка сообщения
  onAddMessage(textMessage: string) {

     const message: Message = {
      text: textMessage,
      sendedTime: new Date(),
      isEdit: false,
      userId: '2' // this.serviceChat.getUserIdFromClaims()
    };
    // '2' - это номер комнаты
     this.serviceRoom.roomAddMessage(message, '2').subscribe(
       (r) => console.log(r)
     , err => console.log('err'));
  }

  // получим пользовательские настройки для чата
  onGetUserSetting() {

     this.serviceChat.chatGetUserSettings(this.serviceChat.getUserIdFromClaims()).subscribe(x => {
        this.userSettins = x;
      }
  );
  }

  // выполним поиск сообщения по шаблону
  onSearchMessage(templateMessageIn: string) {
    this.templateMessage = templateMessageIn;
    this.serviceRoom.roomSearchMessage('2', this.templateMessage).subscribe(x => {
        this.messages = x;
      });
  }
}
