import { Component, OnInit } from '@angular/core';
import { LogService } from '../../../services/log.service';
import { FormGroup, FormControl } from '@angular/forms';
import { PaymentLogEntry } from '../../../models/paymentLogEntry';

@Component({
  selector: 'app-payment-logs',
  templateUrl: './payment-logs.component.html',
  styleUrls: ['./payment-logs.component.css']
})
export class PaymentLogsComponent implements OnInit {
  paymentLogs: PaymentLogEntry[];
  paymentLogTableHeaders = ['Id', 'Дата', 'Id отправителя', 'Id получателя', 'Сумма'];
  paymentLogsFormGroup: FormGroup;
  constructor(private logService: LogService) { }

  ngOnInit() {
    this.paymentLogsFormGroup = new FormGroup({
      dateFrom: new FormControl('2018-12-12'),
      dateTo: new FormControl('2018-12-13'),
      senderId: new FormControl('senderid'),
      reciverId: new FormControl('receiverId'),
      minTransfer: new FormControl(10),
      maxTransfer: new FormControl(20)
    })
  }

  onSubmit() {
    this.logService.getPaymentLogs(this.getParamsString())
      .subscribe(result => this.paymentLogs = result, err => console.error(err))
  }

  getParamsString()  {
    const params = new URLSearchParams();
    const formValue = this.paymentLogsFormGroup.value;

    for (const key in formValue) {
      params.append(key, formValue[key]);
    }
    console.log(params.toString());
    return params.toString();
  }

}
