import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { HistoryGameView } from './history.model';

@Injectable()
export class GameService {
  constructor(private _http: HttpClient) { }
  getHistory() {
    return this._http.get("http://localhost:58843/Game/History");
  }
  
}
