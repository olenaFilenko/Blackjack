import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HistoryGameView } from './history.model';

@Injectable()
export class HistoryService {
  constructor(private _http: HttpClient) { }
  getHistory() {
    return this._http.get("http://localhost:61433/Game/GetGamesHistory");
  }
  
}
