import { Component, OnInit } from '@angular/core';
import { ErrorLogEntry } from '../../../models/errorLogEntry';
import { LogService } from '../../../services/log.service';

@Component({
  selector: 'app-error-logs',
  templateUrl: './error-logs.component.html',
  styleUrls: ['./error-logs.component.css']
})
export class ErrorLogsComponent implements OnInit {
  errorLogs : ErrorLogEntry[];
  errorLogTableHeaders = ['Id', 'Дата', 'Микросервис', 'Тип', 'Hresult', 'InnerEx', 'Сообщение', 'Источник', 'StackTrace', 'TargetSitename'];

  constructor(
    private logService : LogService
  ) { }

  ngOnInit() {
    this.logService.getErrorLogs()
    .subscribe(result => this.errorLogs = result, err => console.error(err))
  }

}