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
  userSettins: Settings;
  newMessage: Message;
  private connection: HubConnection;

  constructor(
    private serviceChat: ChatService, private serviceRoom: RoomService
    ) {
      this.connection = new HubConnectionBuilder()
      .withUrl('http://localhost:61936/chat/notification')
      .build();

      this.connection
      .start()
      .then(() => console.log('Connection established'))
      .catch(err => console.error(err));
      console.log('consrtructor');
    this.connection.on('alertOnSendedMessageAllUsers', msg =>
    (console.log('startMethodHub. Came in method  = ' + msg.Message ),
      this.newMessage = msg.Message,
      console.log('EndMethodHub')
      ))
    ;      console.log('consrtructorEnd');
    console.log(this.newMessage);
     }

  ngOnInit() {
}

  onAddMessage(textMessage: string) {

     const message: Message = {
      text: textMessage,
      sendedTime: new Date(),
      isEdit: false,
      userId: '2'
    };
     this.serviceRoom.roomAddMessage(message, '2' ).subscribe(
       (r) =>console.log(r)
     , err => console.log('err'));
  }

  onGetUserSetting() {

     this.serviceChat.chatGetUserSettings('1').subscribe(x =>
      {

        this.userSettins = x;
      }
  );
  }

  onSearchMessage(templateMessageIn: string){
    this.templateMessage = templateMessageIn;
    this.serviceRoom.roomSearchMessage('1', this.templateMessage).subscribe(x =>
      {
        this.messages = x;
      });
  }
}
