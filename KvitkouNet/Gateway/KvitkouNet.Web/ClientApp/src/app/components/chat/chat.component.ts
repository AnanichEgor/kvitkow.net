import { Settings } from './../../models/chat/settings';
import { Observable } from 'rxjs';
import { Message } from './../../models/chat/message';
import { RoomService } from './../../services/chat/room.service';
import { ChatService } from './../../services/chat/chat.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  chatForm: FormGroup;
  message: Message;
  userSettins: Settings;
  constructor(
    private serviceChat: ChatService, private serviceRoom: RoomService) { }

  ngOnInit() {
}

  onAddMessage(textMessage: string) {

    // const request: EditFeatureRequest = {
    //   featureId: this.selectedFeature.id,
    //   rightsIds: rights.map(function(a) { return a.id; })
    // };

    const message: Message = {
      text: textMessage,
      sendedTime: new Date(),
      isEdit: false,
      userId: '2'
    };
console.log(message);

     this.serviceRoom.roomAddMessage(message, '2' ).subscribe();
  }

  onGetUserSetting() {

     this.serviceChat.chatGetUserSettings('1').subscribe(x =>
      {
        console.log(x);
        this.userSettins = x;
      }
  );
}
}
