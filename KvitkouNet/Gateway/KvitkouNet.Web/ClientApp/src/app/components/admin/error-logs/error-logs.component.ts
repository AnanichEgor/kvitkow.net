import { Component, OnInit } from '@angular/core';
import { ErrorLogEntry } from '../../../models/errorLogEntry';
import { LogService } from '../../../services/log.service';
import {
  FormControl,
  Validators,
  FormGroup,
  FormBuilder
} from '@angular/forms';

@Component({
  selector: 'app-error-logs',
  templateUrl: './error-logs.component.html',
  styleUrls: ['./error-logs.component.css']
})
export class ErrorLogsComponent implements OnInit {
  errorLogs : ErrorLogEntry[];
  errorLogTableHeaders = ['Id', 'Дата', 'Микросервис', 'Тип', 'Hresult', 'InnerEx', 'Сообщение', 'Источник', 'StackTrace', 'TargetSitename'];
  errorLogsFormGroup: FormGroup;
  

  constructor(
    private logService : LogService
  ) { }

  ngOnInit() {
    this.errorLogsFormGroup = new FormGroup({
         serviceName: new FormControl('serviceName'),
         exceptionTypeName: new FormControl('exceptionTypeName'),
         message: new FormControl('message')
       })
  }

  onSubmit() {
    this.logService.getErrorLogs()
    .subscribe(result => this.errorLogs = result, err => console.error(err))
  }

}