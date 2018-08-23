(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["play-game-play-game-module"],{

/***/ "./src/app/play-game/play-game-routing.module.ts":
/*!*******************************************************!*\
  !*** ./src/app/play-game/play-game-routing.module.ts ***!
  \*******************************************************/
/*! exports provided: PlayGameRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayGameRoutingModule", function() { return PlayGameRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _play_game_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./play-game.component */ "./src/app/play-game/play-game.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: _play_game_component__WEBPACK_IMPORTED_MODULE_2__["PlayGameComponent"]
    }
];
var PlayGameRoutingModule = /** @class */ (function () {
    function PlayGameRoutingModule() {
    }
    PlayGameRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], PlayGameRoutingModule);
    return PlayGameRoutingModule;
}());



/***/ }),

/***/ "./src/app/play-game/play-game.component.css":
/*!***************************************************!*\
  !*** ./src/app/play-game/play-game.component.css ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n"

/***/ }),

/***/ "./src/app/play-game/play-game.component.html":
/*!****************************************************!*\
  !*** ./src/app/play-game/play-game.component.html ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h2>Play game</h2>\r\n<div>\r\n  <dl class=\"dl-horizontal\">\r\n    <dt>Game</dt>\r\n    <dd>{{data.name}}</dd>\r\n    <dt>Created</dt>\r\n    <dd>{{data.creationDate| date:'medium'}}</dd>\r\n  </dl>\r\n</div>\r\n<div>\r\n  <button (click)=\"More()\" class=\"btn btn-default\">More</button>\r\n  <button (click)=\"Enough()\" class=\"btn btn-default\">Enough</button>\r\n</div>\r\n<div>\r\n  <table class=\"table\">\r\n    <tr>\r\n      <td>Dealer</td>\r\n      <td>Dealer's points</td>\r\n    </tr>\r\n    <tr>\r\n      <td>{{data.dealer.name}}</td>\r\n      <td>{{data.dealer.points}}</td>\r\n    </tr>\r\n  </table>\r\n</div>\r\n<div>\r\n  <table class=\"table table-bordered\">\r\n    <tr>\r\n      <td>Player</td>\r\n      <td>Player's points</td>\r\n      <td>Player's result</td>\r\n    </tr>\r\n    <tr *ngFor=\"let player of data.players\">\r\n      <td>{{player.name}}</td>\r\n      <td>{{player.points}}</td>\r\n      <td>{{player.result}}</td>\r\n    </tr>\r\n  </table>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/play-game/play-game.component.ts":
/*!**************************************************!*\
  !*** ./src/app/play-game/play-game.component.ts ***!
  \**************************************************/
/*! exports provided: PlayGameComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayGameComponent", function() { return PlayGameComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _shared_play_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./shared/play-game.service */ "./src/app/play-game/shared/play-game.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var PlayGameComponent = /** @class */ (function () {
    function PlayGameComponent(gameService, _Activatedroute, _router) {
        this.gameService = gameService;
        this._Activatedroute = _Activatedroute;
        this._router = _router;
    }
    PlayGameComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._Activatedroute.params.subscribe(function (params) { _this.id = params['id']; });
        this.gameService.getPlay(this.id).subscribe(function (data) {
            _this.data = data;
        });
    };
    PlayGameComponent.prototype.More = function () {
        var _this = this;
        this.gameService.postMore(this.data.id).subscribe(function (response) {
            _this.gameService.getPlay(_this.data.id).subscribe(function (data) {
                _this.data.dealer = data['dealer'];
                _this.data.players = data['players'];
            });
        });
    };
    PlayGameComponent.prototype.Enough = function () {
        var _this = this;
        this.gameService.postEnough(this.data.id).subscribe(function (response) {
            var id = _this.data.id;
            _this._router.navigate(['/result', id]);
        });
    };
    PlayGameComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'play-game-comp',
            template: __webpack_require__(/*! ./play-game.component.html */ "./src/app/play-game/play-game.component.html"),
            styles: [__webpack_require__(/*! ./play-game.component.css */ "./src/app/play-game/play-game.component.css")],
            providers: [_shared_play_game_service__WEBPACK_IMPORTED_MODULE_2__["PlayGameService"]]
        }),
        __metadata("design:paramtypes", [_shared_play_game_service__WEBPACK_IMPORTED_MODULE_2__["PlayGameService"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"]])
    ], PlayGameComponent);
    return PlayGameComponent;
}());



/***/ }),

/***/ "./src/app/play-game/play-game.module.ts":
/*!***********************************************!*\
  !*** ./src/app/play-game/play-game.module.ts ***!
  \***********************************************/
/*! exports provided: PlayGameModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayGameModule", function() { return PlayGameModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _play_game_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./play-game-routing.module */ "./src/app/play-game/play-game-routing.module.ts");
/* harmony import */ var _play_game_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./play-game.component */ "./src/app/play-game/play-game.component.ts");
/* harmony import */ var _shared_shared_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../shared/shared.module */ "./src/app/shared/shared.module.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var PlayGameModule = /** @class */ (function () {
    function PlayGameModule() {
    }
    PlayGameModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_shared_shared_module__WEBPACK_IMPORTED_MODULE_4__["SharedModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClientModule"], _play_game_routing_module__WEBPACK_IMPORTED_MODULE_2__["PlayGameRoutingModule"]],
            declarations: [_play_game_component__WEBPACK_IMPORTED_MODULE_3__["PlayGameComponent"]],
        })
    ], PlayGameModule);
    return PlayGameModule;
}());



/***/ }),

/***/ "./src/app/play-game/shared/play-game.service.ts":
/*!*******************************************************!*\
  !*** ./src/app/play-game/shared/play-game.service.ts ***!
  \*******************************************************/
/*! exports provided: PlayGameService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayGameService", function() { return PlayGameService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


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
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], PlayGameService);
    return PlayGameService;
}());



/***/ })

}]);
//# sourceMappingURL=play-game-play-game-module.js.map