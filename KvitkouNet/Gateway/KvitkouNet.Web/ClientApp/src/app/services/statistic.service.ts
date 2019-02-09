import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class CountryInfo {
  state: string;
  oil: number;
  gas?: number;
  coal?: number;
}

export interface StatisticArray {
  id: number;
  countAll: number;
  countRegistered: number;
  countGuest: number;
  createTime: string;
}

export interface RangeDate {
  startDate: Date;
  endDate: Date;
}

@Injectable()
export class StatisticService {
  constructor(private http: HttpClient) {}

  myMap(item: StatisticArray) {
    const year = new Date(item.createTime).getFullYear();
    const month = new Date(item.createTime).getMonth();

    item.createTime = year + '-' + month;
    return item;
  }

  getRange(range: RangeDate) {
    return this.http.post<StatisticArray[]>(
      'http://localhost:5050/api/statistics/count/range',
      range
    );
  }
}
