(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["start-game-start-game-module"],{

/***/ "./src/app/start-game/shared/start-game.service.ts":
/*!*********************************************************!*\
  !*** ./src/app/start-game/shared/start-game.service.ts ***!
  \*********************************************************/
/*! exports provided: StartGameService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameService", function() { return StartGameService; });
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
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], StartGameService);
    return StartGameService;
}());



/***/ }),

/***/ "./src/app/start-game/start-game-routing.module.ts":
/*!*********************************************************!*\
  !*** ./src/app/start-game/start-game-routing.module.ts ***!
  \*********************************************************/
/*! exports provided: StartGameRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameRoutingModule", function() { return StartGameRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _start_game_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./start-game.component */ "./src/app/start-game/start-game.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: _start_game_component__WEBPACK_IMPORTED_MODULE_2__["StartGameComponent"]
    }
];
var StartGameRoutingModule = /** @class */ (function () {
    function StartGameRoutingModule() {
    }
    StartGameRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], StartGameRoutingModule);
    return StartGameRoutingModule;
}());



/***/ }),

/***/ "./src/app/start-game/start-game.component.css":
/*!*****************************************************!*\
  !*** ./src/app/start-game/start-game.component.css ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".ng-valid[required], .ng-valid.required {\r\n  border-left: 5px solid #42A948; /* green */\r\n}\r\n\r\n.ng-invalid:not(form) {\r\n  border-left: 5px solid #a94442; /* red */\r\n}\r\n"

/***/ }),

/***/ "./src/app/start-game/start-game.component.html":
/*!******************************************************!*\
  !*** ./src/app/start-game/start-game.component.html ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"container\">\r\n  <h2>Start new game</h2>\r\n  <form (ngSubmit)=\"onSubmit()\" #startForm=\"ngForm\">\r\n    <div class=\"form-group\">\r\n      <label for=\"name\" class=\"control-label col-md-2\">Enter name of the game:</label>\r\n      <input type=\"text\" [(ngModel)]=\"data.name\" id=\"name\" name=\"name\" class=\"form-control\" />\r\n    </div>\r\n    <div class=\"form-group\">\r\n      <label for=\"dealersList\" class=\"control-label col-md-2\">Choose dealer:</label>\r\n      <select id=\"dealersList\" required [(ngModel)]=\"data.dealerId\" name=\"dealerId\" class=\"form-control\" #dealerId=\"ngModel\">\r\n        <option *ngFor=\"let dealer of data.dealers\" [value]=\"dealer.id\">{{dealer.name}}</option>\r\n      </select>\r\n      <div [hidden]=\"dealerId.valid||dealerId.untouched\" class=\"alert alert-danger\">\r\n        Enter the dealer\r\n      </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n      <label for=\"playersList\" class=\"control-label col-md-2\">Choose player</label>\r\n      <select id=\"playersList\" required [(ngModel)]=\"data.playerId\" class=\"form-control\" name=\"playerId\" #playerId=\"ngModel\">\r\n        <option *ngFor=\"let player of data.players\" [value]=\"player.id\">{{player.name}}</option>\r\n      </select>\r\n      <div [hidden]=\"playerId.valid||playerId.untouched\" class=\"alert alert-danger\">\r\n        Enter the player\r\n      </div>\r\n      <button *ngIf=\"noNewPlayer\" id=\"addNewPlayer\" (click)=\"addPlayer()\" class=\"btn btn-default\">Add player</button>\r\n      <div *ngIf=\"!noNewPlayer\">\r\n        <label for=\"newPlayerName\" class=\"control-label col-md-2\">Enter new player's name</label>\r\n        <input id=\"newPlayerName\" type=\"text\" [(ngModel)]=\"data.newPlayerName\" name=\"newPlayerName\" class=\"form-control\" #newPlayerName=\"ngModel\"/>\r\n      </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n      <label for=\"botsNumber\" class=\"control-label col-md-2\">Enter bots number</label>\r\n      <input type=\"number\" [(ngModel)]=\"data.botsNumber\" name=\"botsNumber\" id=\"botsNumber\" class=\"form-control\" required pattern=\"[0-5]\" #botsNumber=\"ngModel\" />\r\n      <div [hidden]=\"botsNumber.valid || botsNumber.untouched\" class=\"alert alert-danger\">\r\n        Incorrect enter. Bots number should be between 0 and 5\r\n      </div>\r\n    </div>\r\n    <button type=\"submit\" class=\"btn btn-success\" [disabled]=\"!startForm.form.valid\">Start game</button>\r\n  </form>\r\n</div>\r\n\r\n\r\n\r\n\r\n"

/***/ }),

/***/ "./src/app/start-game/start-game.component.ts":
/*!****************************************************!*\
  !*** ./src/app/start-game/start-game.component.ts ***!
  \****************************************************/
/*! exports provided: StartGameComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameComponent", function() { return StartGameComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _shared_start_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./shared/start-game.service */ "./src/app/start-game/shared/start-game.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var StartGameComponent = /** @class */ (function () {
    function StartGameComponent(gameService, _router) {
        this.gameService = gameService;
        this._router = _router;
    }
    StartGameComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.noNewPlayer = true;
        this.submitted = false;
        this.gameService.getStart().subscribe(function (data) {
            _this.data = data;
        });
    };
    StartGameComponent.prototype.addPlayer = function () {
        this.noNewPlayer = false;
        this.data.playerId = 0;
    };
    StartGameComponent.prototype.onSubmit = function () {
        var _this = this;
        this.gameService.postStart(this.data).subscribe(function (response) {
            var id = response;
            _this._router.navigate(['/play', id]);
        });
    };
    StartGameComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'start-game-comp',
            template: __webpack_require__(/*! ./start-game.component.html */ "./src/app/start-game/start-game.component.html"),
            styles: [__webpack_require__(/*! ./start-game.component.css */ "./src/app/start-game/start-game.component.css")],
            providers: [_shared_start_game_service__WEBPACK_IMPORTED_MODULE_2__["StartGameService"]]
        }),
        __metadata("design:paramtypes", [_shared_start_game_service__WEBPACK_IMPORTED_MODULE_2__["StartGameService"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"]])
    ], StartGameComponent);
    return StartGameComponent;
}());



/***/ }),

/***/ "./src/app/start-game/start-game.module.ts":
/*!*************************************************!*\
  !*** ./src/app/start-game/start-game.module.ts ***!
  \*************************************************/
/*! exports provided: StartGameModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameModule", function() { return StartGameModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _start_game_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./start-game.component */ "./src/app/start-game/start-game.component.ts");
/* harmony import */ var _start_game_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./start-game-routing.module */ "./src/app/start-game/start-game-routing.module.ts");
/* harmony import */ var _shared_shared_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../shared/shared.module */ "./src/app/shared/shared.module.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var StartGameModule = /** @class */ (function () {
    function StartGameModule() {
    }
    StartGameModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_shared_shared_module__WEBPACK_IMPORTED_MODULE_4__["SharedModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClientModule"], _start_game_routing_module__WEBPACK_IMPORTED_MODULE_3__["StartGameRoutingModule"]],
            declarations: [_start_game_component__WEBPACK_IMPORTED_MODULE_2__["StartGameComponent"]]
        })
    ], StartGameModule);
    return StartGameModule;
}());



/***/ })

}]);
//# sourceMappingURL=start-game-start-game-module.js.map