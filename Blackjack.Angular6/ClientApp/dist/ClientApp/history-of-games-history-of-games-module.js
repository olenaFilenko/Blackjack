(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["history-of-games-history-of-games-module"],{

/***/ "./src/app/history-of-games/history-of-games-routing.module.ts":
/*!*********************************************************************!*\
  !*** ./src/app/history-of-games/history-of-games-routing.module.ts ***!
  \*********************************************************************/
/*! exports provided: HistoryRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryRoutingModule", function() { return HistoryRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _history_of_games_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./history-of-games.component */ "./src/app/history-of-games/history-of-games.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: _history_of_games_component__WEBPACK_IMPORTED_MODULE_2__["HistoryComponent"]
    }
];
var HistoryRoutingModule = /** @class */ (function () {
    function HistoryRoutingModule() {
    }
    HistoryRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], HistoryRoutingModule);
    return HistoryRoutingModule;
}());



/***/ }),

/***/ "./src/app/history-of-games/history-of-games.component.css":
/*!*****************************************************************!*\
  !*** ./src/app/history-of-games/history-of-games.component.css ***!
  \*****************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".header{\r\n  background-color:silver;\r\n}\r\n"

/***/ }),

/***/ "./src/app/history-of-games/history-of-games.component.html":
/*!******************************************************************!*\
  !*** ./src/app/history-of-games/history-of-games.component.html ***!
  \******************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h2>Games history</h2>\r\n<button (click)=\"startGame()\" class=\"btn btn-default\">Start new game</button>\r\n<div>\r\n  <table class=\"table\">\r\n    <tr class=\"header\">\r\n      <td>Game</td>\r\n      <td>Dealer</td>\r\n      <td>Player</td>\r\n      <td>Creation date</td>\r\n      <td></td>\r\n    </tr>\r\n    <tr *ngFor=\"let game of data.games\">\r\n      <td>{{game.name}}</td>\r\n      <td>{{game.dealerName}}</td>\r\n      <td>{{game.playerName}}</td>\r\n      <td>{{game.creationDate| date:'medium'}}</td>\r\n      <td>\r\n        <button (click)=\"showResults(game.id)\" class=\"btn btn-default\">Look game's results</button>\r\n      </td>\r\n    </tr>\r\n  </table>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/history-of-games/history-of-games.component.ts":
/*!****************************************************************!*\
  !*** ./src/app/history-of-games/history-of-games.component.ts ***!
  \****************************************************************/
/*! exports provided: HistoryComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryComponent", function() { return HistoryComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_history_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./shared/history.service */ "./src/app/history-of-games/shared/history.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HistoryComponent = /** @class */ (function () {
    function HistoryComponent(gameService, router) {
        this.gameService = gameService;
        this.router = router;
    }
    HistoryComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.gameService.getHistory().subscribe(function (data) {
            _this.data = data;
        });
    };
    HistoryComponent.prototype.showResults = function (id) {
        this.router.navigate(['/result', id]);
    };
    HistoryComponent.prototype.startGame = function () {
        this.router.navigate(['/start']);
    };
    HistoryComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'history-comp',
            template: __webpack_require__(/*! ./history-of-games.component.html */ "./src/app/history-of-games/history-of-games.component.html"),
            styles: [__webpack_require__(/*! ./history-of-games.component.css */ "./src/app/history-of-games/history-of-games.component.css")],
            providers: [_shared_history_service__WEBPACK_IMPORTED_MODULE_1__["HistoryService"]]
        }),
        __metadata("design:paramtypes", [_shared_history_service__WEBPACK_IMPORTED_MODULE_1__["HistoryService"], _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]])
    ], HistoryComponent);
    return HistoryComponent;
}());



/***/ }),

/***/ "./src/app/history-of-games/history-of-games.module.ts":
/*!*************************************************************!*\
  !*** ./src/app/history-of-games/history-of-games.module.ts ***!
  \*************************************************************/
/*! exports provided: HistoryModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryModule", function() { return HistoryModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _history_of_games_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./history-of-games.component */ "./src/app/history-of-games/history-of-games.component.ts");
/* harmony import */ var _history_of_games_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./history-of-games-routing.module */ "./src/app/history-of-games/history-of-games-routing.module.ts");
/* harmony import */ var _shared_shared_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../shared/shared.module */ "./src/app/shared/shared.module.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var HistoryModule = /** @class */ (function () {
    function HistoryModule() {
    }
    HistoryModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _shared_shared_module__WEBPACK_IMPORTED_MODULE_4__["SharedModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClientModule"],
                _history_of_games_routing_module__WEBPACK_IMPORTED_MODULE_3__["HistoryRoutingModule"]
            ],
            declarations: [_history_of_games_component__WEBPACK_IMPORTED_MODULE_2__["HistoryComponent"]],
            providers: []
        })
    ], HistoryModule);
    return HistoryModule;
}());



/***/ }),

/***/ "./src/app/history-of-games/shared/history.service.ts":
/*!************************************************************!*\
  !*** ./src/app/history-of-games/shared/history.service.ts ***!
  \************************************************************/
/*! exports provided: HistoryService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryService", function() { return HistoryService; });
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


var HistoryService = /** @class */ (function () {
    function HistoryService(_http) {
        this._http = _http;
    }
    HistoryService.prototype.getHistory = function () {
        return this._http.get("http://localhost:61433/api/Game/GetGamesHistory");
    };
    HistoryService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], HistoryService);
    return HistoryService;
}());



/***/ })

}]);
//# sourceMappingURL=history-of-games-history-of-games-module.js.map