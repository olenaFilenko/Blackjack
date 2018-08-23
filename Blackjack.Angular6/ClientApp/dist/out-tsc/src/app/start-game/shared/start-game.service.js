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
var StartGameService = /** @class */ (function () {
    function StartGameService(_http) {
        this._http = _http;
    }
    StartGameService.prototype.getStart = function () {
        return this._http.get("http://localhost:61433/api/Game/GetStart");
    };
    StartGameService.prototype.postStart = function (start) {
        //let body = JSON.stringify(start);
        return this._http.post("http://localhost:61433/api/Game/PostGame", start);
    };
    StartGameService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], StartGameService);
    return StartGameService;
}());
export { StartGameService };
//# sourceMappingURL=start-game.service.js.map