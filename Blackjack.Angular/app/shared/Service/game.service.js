var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
var GameService = /** @class */ (function () {
    function GameService(_http) {
        this._http = _http;
    }
    GameService.prototype.getHistory = function () {
        return this._http.get("http://localhost:58843/Game/History");
    };
    GameService.prototype.getDetails = function (id) {
        var params = new HttpParams().set('id', id.toString());
        return this._http.get("http://localhost:58843/Game/Details", { params: params });
    };
    GameService.prototype.getPlay = function (id) {
        var params = new HttpParams().set('id', id.toString());
        return this._http.get("http://localhost:58843/Game/Play", { params: params });
    };
    GameService.prototype.getStart = function () {
        return this._http.get("http://localhost:58843/Game/Start");
    };
    GameService.prototype.postStart = function (start) {
        var body = JSON.stringify(start);
        return this._http.post("http://localhost:58843/Game/Start", body);
    };
    GameService.prototype.postMore = function (id) {
        var params = new HttpParams().set('gameId', id.toString());
        this._http.post("http://localhost:58843/Game/More", { params: params });
    };
    GameService.prototype.postEnough = function (id) {
        var params = new HttpParams().set('gameId', id.toString());
        this._http.post("http://localhost:58843/Game/Enough", { params: params });
    };
    GameService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], GameService);
    return GameService;
}());
export { GameService };
//# sourceMappingURL=game.service.js.map