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
import { HttpClient } from '@angular/common/http';
var PlayGameService = /** @class */ (function () {
    function PlayGameService(_http) {
        this._http = _http;
    }
    PlayGameService.prototype.getPlay = function (id) {
        //const params = new HttpParams().set('id', id.toString());
        return this._http.get("http://localhost:61433/api/Game/GetPlay/" + id);
    };
    PlayGameService.prototype.postMore = function (id) {
        //const params = new HttpParams().set('id', id.toString())
        //  .set('isMoreRequred', (true).valueOf.toString());
        return this._http.put("http://localhost:61433/api/Game/More/" + id, null);
    };
    PlayGameService.prototype.postEnough = function (id) {
        //const params = new HttpParams().set('id', id.toString())
        //  .set('isMoreRequred', (false).valueOf.toString());
        return this._http.put("http://localhost:61433/api/Game/Enough/" + id, null);
    };
    PlayGameService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], PlayGameService);
    return PlayGameService;
}());
export { PlayGameService };
//# sourceMappingURL=play-game.service.js.map