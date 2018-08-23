(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["game-result-game-result-module"],{

/***/ "./src/app/game-result/game-result-routing.module.ts":
/*!***********************************************************!*\
  !*** ./src/app/game-result/game-result-routing.module.ts ***!
  \***********************************************************/
/*! exports provided: GameResultRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameResultRoutingModule", function() { return GameResultRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _game_result_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./game-result.component */ "./src/app/game-result/game-result.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: _game_result_component__WEBPACK_IMPORTED_MODULE_2__["GameResultComponent"]
    }
];
var GameResultRoutingModule = /** @class */ (function () {
    function GameResultRoutingModule() {
    }
    GameResultRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], GameResultRoutingModule);
    return GameResultRoutingModule;
}());



/***/ }),

/***/ "./src/app/game-result/game-result.component.css":
/*!*******************************************************!*\
  !*** ./src/app/game-result/game-result.component.css ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n"

/***/ }),

/***/ "./src/app/game-result/game-result.component.html":
/*!********************************************************!*\
  !*** ./src/app/game-result/game-result.component.html ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h2>Game's results</h2>\r\n<div>\r\n  <dl class=\"dl-horizontal\">\r\n    <dt>Game</dt>\r\n    <dd>{{data.name}}</dd>\r\n    <dt>Created</dt>\r\n    <dd>{{data.creationDate| date:'medium'}}</dd>\r\n  </dl>\r\n</div>\r\n<div>\r\n  <table class=\"table\">\r\n    <tr>\r\n      <td>Dealer</td>\r\n      <td>Dealer's points</td>\r\n    </tr>\r\n    <tr>\r\n      <td>{{data.dealer.name}}</td>\r\n      <td>{{data.dealer.points}}</td>\r\n    </tr>\r\n  </table>\r\n</div>\r\n<div>\r\n  <table class=\"table table-bordered\">\r\n    <tr>\r\n      <td>Player</td>\r\n      <td>Player's points</td>\r\n      <td>Player's result</td>\r\n    </tr>\r\n    <tr *ngFor=\"let player of data.players\">\r\n      <td>{{player.name}}</td>\r\n      <td>{{player.points}}</td>\r\n      <td>{{player.result}}</td>\r\n    </tr>\r\n  </table>\r\n  <button (click)=\"back()\" class=\"btn btn-default\">Back to history</button>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/game-result/game-result.component.ts":
/*!******************************************************!*\
  !*** ./src/app/game-result/game-result.component.ts ***!
  \******************************************************/
/*! exports provided: GameResultComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameResultComponent", function() { return GameResultComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _shared_game_result_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./shared/game-result.service */ "./src/app/game-result/shared/game-result.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var GameResultComponent = /** @class */ (function () {
    function GameResultComponent(gameService, _Activatedroute, _router) {
        this.gameService = gameService;
        this._Activatedroute = _Activatedroute;
        this._router = _router;
    }
    GameResultComponent.prototype.back = function () {
        this._router.navigate(['/history']);
    };
    GameResultComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._Activatedroute.params.subscribe(function (params) { _this.id = params['id']; });
        this.gameService.getDetails(this.id).subscribe(function (data) {
            _this.data = data;
        });
    };
    GameResultComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'game-result-comp',
            template: __webpack_require__(/*! ./game-result.component.html */ "./src/app/game-result/game-result.component.html"),
            styles: [__webpack_require__(/*! ./game-result.component.css */ "./src/app/game-result/game-result.component.css")],
            providers: [_shared_game_result_service__WEBPACK_IMPORTED_MODULE_2__["ResultGameService"]]
        }),
        __metadata("design:paramtypes", [_shared_game_result_service__WEBPACK_IMPORTED_MODULE_2__["ResultGameService"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"]])
    ], GameResultComponent);
    return GameResultComponent;
}());



/***/ }),

/***/ "./src/app/game-result/game-result.module.ts":
/*!***************************************************!*\
  !*** ./src/app/game-result/game-result.module.ts ***!
  \***************************************************/
/*! exports provided: GameResultModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameResultModule", function() { return GameResultModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _game_result_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./game-result.component */ "./src/app/game-result/game-result.component.ts");
/* harmony import */ var _game_result_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./game-result-routing.module */ "./src/app/game-result/game-result-routing.module.ts");
/* harmony import */ var _shared_shared_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../shared/shared.module */ "./src/app/shared/shared.module.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var GameResultModule = /** @class */ (function () {
    function GameResultModule() {
    }
    GameResultModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_shared_shared_module__WEBPACK_IMPORTED_MODULE_4__["SharedModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClientModule"], _game_result_routing_module__WEBPACK_IMPORTED_MODULE_3__["GameResultRoutingModule"]],
            declarations: [_game_result_component__WEBPACK_IMPORTED_MODULE_2__["GameResultComponent"]]
        })
    ], GameResultModule);
    return GameResultModule;
}());



/***/ }),

/***/ "./src/app/game-result/shared/game-result.service.ts":
/*!***********************************************************!*\
  !*** ./src/app/game-result/shared/game-result.service.ts ***!
  \***********************************************************/
/*! exports provided: ResultGameService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ResultGameService", function() { return ResultGameService; });
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


var ResultGameService = /** @class */ (function () {
    function ResultGameService(_http) {
        this._http = _http;
    }
    ResultGameService.prototype.getDetails = function (id) {
        //const params = new HttpParams().set('id', id.toString());
        return this._http.get("http://localhost:61433/api/Game/details/" + id);
    };
    ResultGameService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], ResultGameService);
    return ResultGameService;
}());



/***/ })

}]);
//# sourceMappingURL=game-result-game-result-module.js.map