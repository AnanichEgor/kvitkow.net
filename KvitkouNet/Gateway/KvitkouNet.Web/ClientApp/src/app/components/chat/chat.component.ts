import { RoomService } from './../../services/chat/room.service';
import { ChatService } from './../../services/chat/chat.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  constructor(
    private serviceChat: ChatService,
    private serviceRoom: RoomService) { }

  ngOnInit() {
  }

}
