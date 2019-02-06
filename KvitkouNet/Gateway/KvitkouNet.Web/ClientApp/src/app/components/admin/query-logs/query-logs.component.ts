import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { QueryLogEntry } from '../../../models/queryLogEntry';
import { LogService } from '../../../services/log.service';

@Component({
  selector: 'app-query-logs',
  templateUrl: './query-logs.component.html',
  styleUrls: ['./query-logs.component.css']
})
export class QueryLogsComponent implements OnInit {
  queryLogs: QueryLogEntry[];
  queryLogTableHeaders = ['Id', 'Дата', 'UserId', 'Поисковый критерий', 'Фильтры'];
  queryLogsFormGroup: FormGroup;
  constructor(private logService: LogService) { }

  ngOnInit() {
    this.queryLogsFormGroup = new FormGroup({
      dateFrom: new FormControl('2018-12-12'),
      dateTo: new FormControl('2018-12-13'),
      userId: new FormControl('userId'),
      criterium: new FormControl('criterium')
    })
  }

  onSubmit() {
    this.logService.getQueryLogs(this.getParamsString())
      .subscribe(result => this.queryLogs = result, err => console.error(err))
  }

  getParamsString()  {
    const params = new URLSearchParams();
    const formValue = this.queryLogsFormGroup.value;

    for (const key in formValue) {
      params.append(key, formValue[key]);
    }
    console.log(params.toString());
    return params.toString();
  }

}
