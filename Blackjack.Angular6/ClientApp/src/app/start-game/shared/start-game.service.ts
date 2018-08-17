import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { StartGameView } from './start-game.model';

@Injectable()
export class StartGameService {
  constructor(private _http: HttpClient) { }
 
  getStart() {
    return this._http.get("http://localhost:61433/Game/GetStart");
  }

  postStart(start: StartGameView) {
    let body = JSON.stringify(start);
    return this._http.post("http://localhost:61433/Game/PostGame", body);
  }
  
}
