import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class CountryInfo {
  state: string;
  oil: number;
  gas?: number;
  coal?: number;
}

const countriesInfo: CountryInfo[] = [
  {
    state: 'China',
    oil: 4.95,
    gas: 2.85,
    coal: 45.56
  },
  {
    state: 'Russia',
    oil: 12.94,
    gas: 17.66,
    coal: 4.13
  },
  {
    state: 'USA',
    oil: 8.51,
    gas: 19.87,
    coal: 15.84
  },
  {
    state: 'Iran',
    oil: 5.3,
    gas: 4.39
  },
  {
    state: 'Canada',
    oil: 4.08,
    gas: 5.4
  },
  {
    state: 'Saudi Arabia',
    oil: 12.03
  },
  {
    state: 'Mexico',
    oil: 3.86
  }
];

const UsersArray = [
  {
    id: 110,
    countAll: 105,
    countRegistered: 89,
    countGuest: 9,
    createTime: '2017-02-15T01:53:21.0936411'
  },
  {
    id: 6,
    countAll: 165,
    countRegistered: 83,
    countGuest: 32,
    createTime: '2017-02-16T14:15:33.6015294'
  },
  {
    id: 131,
    countAll: 156,
    countRegistered: 40,
    countGuest: 62,
    createTime: '2017-02-20T08:23:52.681667'
  },
  {
    id: 46,
    countAll: 156,
    countRegistered: 79,
    countGuest: 81,
    createTime: '2017-02-25T14:46:10.2677583'
  },
  {
    id: 108,
    countAll: 177,
    countRegistered: 9,
    countGuest: 18,
    createTime: '2017-03-04T17:14:44.8274701'
  },
  {
    id: 120,
    countAll: 168,
    countRegistered: 5,
    countGuest: 21,
    createTime: '2017-03-27T05:06:23.1522484'
  },
  {
    id: 54,
    countAll: 139,
    countRegistered: 97,
    countGuest: 74,
    createTime: '2017-04-14T18:13:15.7800765'
  },
  {
    id: 145,
    countAll: 162,
    countRegistered: 65,
    countGuest: 79,
    createTime: '2017-04-18T02:42:24.2421679'
  },
  {
    id: 146,
    countAll: 111,
    countRegistered: 37,
    countGuest: 16,
    createTime: '2017-04-23T01:06:10.3555206'
  },
  {
    id: 63,
    countAll: 119,
    countRegistered: 32,
    countGuest: 78,
    createTime: '2017-05-08T11:50:43.5192636'
  },
  {
    id: 53,
    countAll: 112,
    countRegistered: 72,
    countGuest: 76,
    createTime: '2017-05-08T18:59:47.8927397'
  },
  {
    id: 148,
    countAll: 155,
    countRegistered: 70,
    countGuest: 55,
    createTime: '2017-05-13T11:00:17.5768734'
  },
  {
    id: 73,
    countAll: 163,
    countRegistered: 56,
    countGuest: 58,
    createTime: '2017-05-18T12:07:56.2849543'
  },
  {
    id: 83,
    countAll: 163,
    countRegistered: 23,
    countGuest: 30,
    createTime: '2017-05-26T17:47:51.2495357'
  },
  {
    id: 48,
    countAll: 160,
    countRegistered: 24,
    countGuest: 47,
    createTime: '2017-06-05T23:11:58.0825685'
  },
  {
    id: 51,
    countAll: 108,
    countRegistered: 28,
    countGuest: 84,
    createTime: '2017-06-08T03:25:46.7875069'
  },
  {
    id: 150,
    countAll: 113,
    countRegistered: 48,
    countGuest: 50,
    createTime: '2017-06-11T10:05:21.8429585'
  },
  {
    id: 42,
    countAll: 187,
    countRegistered: 25,
    countGuest: 0,
    createTime: '2017-06-18T01:07:57.4717295'
  },
  {
    id: 17,
    countAll: 166,
    countRegistered: 50,
    countGuest: 98,
    createTime: '2017-07-04T09:10:52.1400122'
  },
  {
    id: 21,
    countAll: 123,
    countRegistered: 58,
    countGuest: 58,
    createTime: '2017-07-11T13:44:27.2150283'
  },
  {
    id: 90,
    countAll: 126,
    countRegistered: 82,
    countGuest: 16,
    createTime: '2017-07-17T17:12:57.3625483'
  },
  {
    id: 124,
    countAll: 117,
    countRegistered: 33,
    countGuest: 76,
    createTime: '2017-07-17T21:46:15.5591281'
  },
  {
    id: 114,
    countAll: 154,
    countRegistered: 53,
    countGuest: 45,
    createTime: '2017-07-23T23:40:44.3909312'
  },
  {
    id: 22,
    countAll: 188,
    countRegistered: 29,
    countGuest: 58,
    createTime: '2017-07-28T02:46:39.2532279'
  },
  {
    id: 1,
    countAll: 164,
    countRegistered: 36,
    countGuest: 75,
    createTime: '2017-08-01T13:34:43.1362941'
  },
  {
    id: 80,
    countAll: 124,
    countRegistered: 4,
    countGuest: 32,
    createTime: '2017-08-09T17:09:25.8160015'
  },
  {
    id: 28,
    countAll: 180,
    countRegistered: 6,
    countGuest: 15,
    createTime: '2017-08-12T05:52:09.5196071'
  },
  {
    id: 97,
    countAll: 166,
    countRegistered: 64,
    countGuest: 60,
    createTime: '2017-08-16T22:28:24.3182597'
  },
  {
    id: 24,
    countAll: 143,
    countRegistered: 73,
    countGuest: 89,
    createTime: '2017-08-18T01:16:16.7093559'
  },
  {
    id: 58,
    countAll: 159,
    countRegistered: 64,
    countGuest: 5,
    createTime: '2017-08-23T15:49:36.229409'
  },
  {
    id: 140,
    countAll: 187,
    countRegistered: 61,
    countGuest: 27,
    createTime: '2017-08-28T15:06:12.9866335'
  },
  {
    id: 105,
    countAll: 138,
    countRegistered: 73,
    countGuest: 38,
    createTime: '2017-08-28T20:48:26.3281941'
  },
  {
    id: 5,
    countAll: 180,
    countRegistered: 30,
    countGuest: 33,
    createTime: '2017-08-29T18:24:01.8289333'
  },
  {
    id: 9,
    countAll: 134,
    countRegistered: 82,
    countGuest: 13,
    createTime: '2017-09-04T00:26:01.3202804'
  },
  {
    id: 56,
    countAll: 143,
    countRegistered: 9,
    countGuest: 83,
    createTime: '2017-09-04T19:55:52.5189625'
  },
  {
    id: 26,
    countAll: 175,
    countRegistered: 26,
    countGuest: 85,
    createTime: '2017-09-07T15:18:19.3767251'
  },
  {
    id: 62,
    countAll: 151,
    countRegistered: 2,
    countGuest: 80,
    createTime: '2017-09-07T21:11:10.4719465'
  },
  {
    id: 16,
    countAll: 168,
    countRegistered: 23,
    countGuest: 5,
    createTime: '2017-09-23T21:15:25.5541818'
  },
  {
    id: 126,
    countAll: 100,
    countRegistered: 32,
    countGuest: 55,
    createTime: '2017-10-02T01:11:09.6708481'
  },
  {
    id: 113,
    countAll: 115,
    countRegistered: 34,
    countGuest: 35,
    createTime: '2017-10-22T21:04:51.2489164'
  },
  {
    id: 92,
    countAll: 161,
    countRegistered: 95,
    countGuest: 22,
    createTime: '2017-10-26T20:30:33.1982949'
  },
  {
    id: 127,
    countAll: 145,
    countRegistered: 38,
    countGuest: 88,
    createTime: '2017-11-09T20:02:48.1317255'
  },
  {
    id: 132,
    countAll: 157,
    countRegistered: 8,
    countGuest: 46,
    createTime: '2017-11-15T21:56:00.4578486'
  },
  {
    id: 134,
    countAll: 113,
    countRegistered: 45,
    countGuest: 86,
    createTime: '2017-11-17T19:33:36.0793657'
  },
  {
    id: 81,
    countAll: 164,
    countRegistered: 72,
    countGuest: 68,
    createTime: '2017-11-27T02:41:40.6148212'
  },
  {
    id: 64,
    countAll: 110,
    countRegistered: 63,
    countGuest: 21,
    createTime: '2017-12-04T06:54:22.5837163'
  },
  {
    id: 104,
    countAll: 161,
    countRegistered: 48,
    countGuest: 95,
    createTime: '2017-12-29T16:37:33.6437487'
  },
  {
    id: 13,
    countAll: 172,
    countRegistered: 56,
    countGuest: 91,
    createTime: '2018-01-07T21:45:59.5617834'
  },
  {
    id: 82,
    countAll: 126,
    countRegistered: 91,
    countGuest: 49,
    createTime: '2018-01-15T19:06:34.4452395'
  },
  {
    id: 55,
    countAll: 171,
    countRegistered: 16,
    countGuest: 13,
    createTime: '2018-03-02T15:07:03.2350576'
  },
  {
    id: 75,
    countAll: 103,
    countRegistered: 18,
    countGuest: 57,
    createTime: '2018-03-24T16:30:56.3602813'
  },
  {
    id: 111,
    countAll: 122,
    countRegistered: 84,
    countGuest: 8,
    createTime: '2018-04-03T04:32:26.2068738'
  },
  {
    id: 45,
    countAll: 138,
    countRegistered: 74,
    countGuest: 27,
    createTime: '2018-04-13T22:49:22.0327866'
  },
  {
    id: 147,
    countAll: 174,
    countRegistered: 36,
    countGuest: 20,
    createTime: '2018-04-23T21:35:51.8241612'
  },
  {
    id: 71,
    countAll: 162,
    countRegistered: 42,
    countGuest: 92,
    createTime: '2018-04-24T15:56:52.5959248'
  },
  {
    id: 103,
    countAll: 192,
    countRegistered: 24,
    countGuest: 83,
    createTime: '2018-04-26T12:05:51.4444144'
  },
  {
    id: 23,
    countAll: 177,
    countRegistered: 82,
    countGuest: 100,
    createTime: '2018-04-28T12:32:31.2837825'
  },
  {
    id: 8,
    countAll: 193,
    countRegistered: 83,
    countGuest: 73,
    createTime: '2018-05-12T12:36:59.5408923'
  },
  {
    id: 137,
    countAll: 165,
    countRegistered: 96,
    countGuest: 28,
    createTime: '2018-05-15T19:07:02.015965'
  },
  {
    id: 91,
    countAll: 164,
    countRegistered: 64,
    countGuest: 49,
    createTime: '2018-05-18T16:06:11.5791281'
  },
  {
    id: 47,
    countAll: 169,
    countRegistered: 31,
    countGuest: 96,
    createTime: '2018-06-05T08:35:12.1888812'
  },
  {
    id: 116,
    countAll: 183,
    countRegistered: 67,
    countGuest: 37,
    createTime: '2018-06-07T05:39:38.0001229'
  },
  {
    id: 115,
    countAll: 176,
    countRegistered: 89,
    countGuest: 53,
    createTime: '2018-06-18T18:10:50.9029185'
  },
  {
    id: 102,
    countAll: 183,
    countRegistered: 100,
    countGuest: 85,
    createTime: '2018-06-28T09:38:20.7668066'
  },
  {
    id: 74,
    countAll: 161,
    countRegistered: 98,
    countGuest: 92,
    createTime: '2018-07-01T18:16:58.0173109'
  },
  {
    id: 19,
    countAll: 174,
    countRegistered: 10,
    countGuest: 6,
    createTime: '2018-07-01T20:41:25.4320088'
  },
  {
    id: 70,
    countAll: 137,
    countRegistered: 39,
    countGuest: 26,
    createTime: '2018-07-05T05:56:52.0441225'
  },
  {
    id: 142,
    countAll: 137,
    countRegistered: 65,
    countGuest: 39,
    createTime: '2018-07-11T06:36:28.9537994'
  },
  {
    id: 107,
    countAll: 118,
    countRegistered: 71,
    countGuest: 52,
    createTime: '2018-07-18T04:23:26.5528139'
  },
  {
    id: 101,
    countAll: 127,
    countRegistered: 16,
    countGuest: 84,
    createTime: '2018-07-22T15:31:47.8284512'
  },
  {
    id: 41,
    countAll: 188,
    countRegistered: 94,
    countGuest: 13,
    createTime: '2018-07-24T03:10:57.5738456'
  },
  {
    id: 60,
    countAll: 191,
    countRegistered: 77,
    countGuest: 31,
    createTime: '2018-07-26T10:20:15.7147799'
  },
  {
    id: 135,
    countAll: 119,
    countRegistered: 47,
    countGuest: 69,
    createTime: '2018-07-28T07:48:56.7662489'
  },
  {
    id: 50,
    countAll: 143,
    countRegistered: 40,
    countGuest: 72,
    createTime: '2018-07-30T11:15:40.1393638'
  },
  {
    id: 44,
    countAll: 112,
    countRegistered: 24,
    countGuest: 51,
    createTime: '2018-08-23T18:57:22.4264444'
  },
  {
    id: 139,
    countAll: 131,
    countRegistered: 87,
    countGuest: 90,
    createTime: '2018-08-25T03:56:58.1969716'
  },
  {
    id: 4,
    countAll: 191,
    countRegistered: 72,
    countGuest: 79,
    createTime: '2018-08-25T09:54:07.7801356'
  },
  {
    id: 86,
    countAll: 189,
    countRegistered: 98,
    countGuest: 18,
    createTime: '2018-08-31T10:04:22.853436'
  },
  {
    id: 68,
    countAll: 174,
    countRegistered: 58,
    countGuest: 0,
    createTime: '2018-09-06T02:16:14.8327499'
  },
  {
    id: 39,
    countAll: 131,
    countRegistered: 63,
    countGuest: 88,
    createTime: '2018-09-09T09:35:48.4197195'
  },
  {
    id: 77,
    countAll: 143,
    countRegistered: 12,
    countGuest: 100,
    createTime: '2018-10-08T02:08:18.1393659'
  },
  {
    id: 14,
    countAll: 117,
    countRegistered: 49,
    countGuest: 89,
    createTime: '2018-10-16T17:55:36.9902834'
  },
  {
    id: 38,
    countAll: 122,
    countRegistered: 42,
    countGuest: 90,
    createTime: '2018-10-18T16:13:21.2853276'
  },
  {
    id: 7,
    countAll: 173,
    countRegistered: 73,
    countGuest: 15,
    createTime: '2018-10-25T11:46:16.7883109'
  },
  {
    id: 112,
    countAll: 123,
    countRegistered: 75,
    countGuest: 37,
    createTime: '2018-10-31T13:19:54.8950364'
  },
  {
    id: 99,
    countAll: 177,
    countRegistered: 84,
    countGuest: 57,
    createTime: '2018-10-31T21:31:22.2278323'
  },
  {
    id: 138,
    countAll: 149,
    countRegistered: 94,
    countGuest: 80,
    createTime: '2018-11-04T19:49:24.6119156'
  },
  {
    id: 118,
    countAll: 144,
    countRegistered: 12,
    countGuest: 64,
    createTime: '2018-11-11T09:40:49.1049442'
  },
  {
    id: 52,
    countAll: 120,
    countRegistered: 98,
    countGuest: 48,
    createTime: '2018-11-24T11:50:32.1592823'
  },
  {
    id: 27,
    countAll: 147,
    countRegistered: 68,
    countGuest: 71,
    createTime: '2018-11-25T10:38:10.2549374'
  },
  {
    id: 133,
    countAll: 119,
    countRegistered: 20,
    countGuest: 59,
    createTime: '2018-12-04T03:26:33.2224968'
  },
  {
    id: 29,
    countAll: 128,
    countRegistered: 90,
    countGuest: 80,
    createTime: '2018-12-06T16:42:12.8901668'
  },
  {
    id: 130,
    countAll: 189,
    countRegistered: 93,
    countGuest: 91,
    createTime: '2018-12-12T20:26:54.0210254'
  },
  {
    id: 15,
    countAll: 150,
    countRegistered: 7,
    countGuest: 52,
    createTime: '2018-12-14T21:50:21.9145381'
  },
  {
    id: 87,
    countAll: 196,
    countRegistered: 75,
    countGuest: 77,
    createTime: '2018-12-25T11:32:39.0250784'
  },
  {
    id: 125,
    countAll: 184,
    countRegistered: 36,
    countGuest: 50,
    createTime: '2018-12-25T22:00:21.0496961'
  },
  {
    id: 129,
    countAll: 167,
    countRegistered: 91,
    countGuest: 90,
    createTime: '2019-01-04T10:11:29.6942157'
  },
  {
    id: 121,
    countAll: 132,
    countRegistered: 79,
    countGuest: 3,
    createTime: '2019-01-11T20:25:38.455082'
  },
  {
    id: 94,
    countAll: 189,
    countRegistered: 20,
    countGuest: 71,
    createTime: '2019-01-24T03:13:44.8416981'
  },
  {
    id: 117,
    countAll: 156,
    countRegistered: 75,
    countGuest: 100,
    createTime: '2019-01-25T11:13:14.8780833'
  },
  {
    id: 100,
    countAll: 174,
    countRegistered: 100,
    countGuest: 43,
    createTime: '2019-01-29T14:30:29.9134544'
  },
  {
    id: 144,
    countAll: 118,
    countRegistered: 26,
    countGuest: 11,
    createTime: '2019-02-02T02:33:22.6748359'
  }
];

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
  getCountriesInfo(): StatisticArray[] {
    return UsersArray.map(this.myMap);
  }

  getRange(range: RangeDate) {
    return this.http.post<StatisticArray[]>(
      'http://localhost:5050/api/statistics/count/range',
      range
    );
  }
}
