import { Component, OnInit } from '@angular/core';
import { LogService } from '../../../services/log.service';
import { AccountLogEntry } from '../../../models/accountLogEntry';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-account-logs',
  templateUrl: './account-logs.component.html',
  styleUrls: ['./account-logs.component.css']
})
export class AccountLogsComponent implements OnInit {
  accountLogs: AccountLogEntry[];
  accountLogTableHeaders = ['Id', 'Дата', 'Id пользователя', 'Имя', 'Email', 'Тип'];
  accountLogsFormGroup: FormGroup;
  constructor(private logService: LogService) { }

  ngOnInit() {
  }

}
