import { StatisticService, StatisticArray, RangeDate } from './../../services/statistic.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {
  userList: StatisticArray[] = [];
  range: RangeDate = {startDate: new Date(), endDate: new Date()};

  constructor(private statisticService: StatisticService) {
    this.setDate(1);
  }

  setDate(year: number) {
    this.range.startDate.setFullYear(new Date().getFullYear() - year);
  }

  ConvertDate(item: StatisticArray) {
    const year = new Date(item.createTime).getFullYear();
    const month = new Date(item.createTime).getMonth() + 1;

    item.createTime = year + '/' + month;
    return item;
  }

  getStatistic() {
    this.statisticService.getRange(this.range)
    .subscribe(result => (this.userList = result.map(this.ConvertDate)), err => console.log(err));
  }

  clickRange(year: number) {
    this.setDate(year);
    this.getStatistic();
  }

  ngOnInit() {
    this.statisticService.getRange(this.range)
      .subscribe(result => (this.userList = result.map(this.ConvertDate)), err => console.log(err));
  }
}


