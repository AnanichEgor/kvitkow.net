import { Component, OnInit } from '@angular/core';
import { LogService } from '../../../services/log.service';
import { DealLogEntry } from '../../../models/dealLogEntry';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-deal-logs',
  templateUrl: './deal-logs.component.html',
  styleUrls: ['./deal-logs.component.css']
})
export class DealLogsComponent implements OnInit {
  dealLogs: DealLogEntry[];
  dealLogTableHeaders = ['Id', 'Дата', 'Id владельца', 'Id получателя', 'Цена', 'Тип'];
  dealLogsFormGroup: FormGroup;
  constructor(private logService: LogService) {}

  ngOnInit() {
    this.dealLogsFormGroup = new FormGroup({
      dateFrom: new FormControl('2018-12-12'),
      dateTo: new FormControl('2018-12-13'),
      ticketId: new FormControl('ticketId'),
      ownerId: new FormControl('ownerId'),
      recieverId: new FormControl('recieverId'),
      minPrice: new FormControl(0),
      maxPrice: new FormControl(1),
      type: new FormControl(0)
    })
  }

  onSubmit() {
    this.logService.getDealLogs(this.getParamsString())
      .subscribe(result => this.dealLogs = result, err => console.error(err))
  }

  getParamsString()  {
    const params = new URLSearchParams();
    const formValue = this.dealLogsFormGroup.value;

    for (const key in formValue) {
      params.append(key, formValue[key]);
    }
     return params.toString();
  }

}
