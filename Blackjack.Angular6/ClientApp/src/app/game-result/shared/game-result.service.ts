import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';



@Injectable()
export class ResultGameService {
  constructor(private _http: HttpClient) { }

  getDetails(id: number) {
    //const params = new HttpParams().set('id', id.toString());
    return this._http.get("http://localhost:61433/api/Game/details/" + id);
  }

}
