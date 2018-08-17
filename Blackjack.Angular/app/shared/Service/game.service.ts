import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { StartGameView } from '../Models/startGameView';
import { HistoryGameView } from '../Models/historyGameView';

@Injectable()
export class GameService {
    constructor(private _http: HttpClient) { }
    getHistory(){
        return this._http.get("http://localhost:58843/Game/History");
    }
    getDetails(id: number) {
        const params = new HttpParams().set('id', id.toString());
        return this._http.get("http://localhost:58843/Game/Details", { params })
    }
    getPlay(id: number) {
        const params = new HttpParams().set('id', id.toString());
        return this._http.get("http://localhost:58843/Game/Play", { params })
    }
    getStart() {
        return this._http.get("http://localhost:58843/Game/Start");
    }

    postStart(start: StartGameView) {
        let body = JSON.stringify(start);
        return this._http.post("http://localhost:58843/Game/Start", body);
    }

    postMore(id: number) {
        const params = new HttpParams().set('gameId', id.toString());
        this._http.post("http://localhost:58843/Game/More", {params})
    }

    postEnough(id: number) {
        const params = new HttpParams().set('gameId', id.toString());
        this._http.post("http://localhost:58843/Game/Enough", { params})
    }
}