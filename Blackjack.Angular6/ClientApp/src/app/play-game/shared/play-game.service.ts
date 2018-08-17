import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';



@Injectable()
export class PlayGameService {
  constructor(private _http: HttpClient) { }

  getPlay(id: number) {
    const params = new HttpParams().set('id', id.toString());
    return this._http.get("http://localhost:61433/Game/GetPlay", { params })
  }

  postMore(id: number) {
    const params = new HttpParams().set('id', id.toString())
      .set('isMoreRequred', (true).valueOf.toString());
    this._http.post("http://localhost:61433/Game/PutPlayerAction", { params })
  }

  postEnough(id: number) {
    const params = new HttpParams().set('id', id.toString())
      .set('isMoreRequred', (false).valueOf.toString());
    this._http.post("http://localhost:61433/Game/PutPlayerAction", { params })
  }
}
