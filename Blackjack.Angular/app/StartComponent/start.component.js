var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { GameService } from '../shared/Service/game.service';
import { Router } from '@angular/router';
var StartComponent = /** @class */ (function () {
    function StartComponent(gameService, _router) {
        this.gameService = gameService;
        this._router = _router;
    }
    StartComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.noNewPlayer = true;
        this.gameService.getStart().subscribe(function (data) {
            _this.data.dealers = data['dealers'];
            _this.data.players = data['players'];
        });
    };
    StartComponent.prototype.addPlayer = function () {
        this.noNewPlayer = false;
    };
    StartComponent.prototype.createNewPlayer = function () {
        this.data.players.push({ id: 0, name: this.data.newPlayerName });
    };
    StartComponent.prototype.submit = function () {
        var _this = this;
        this.gameService.postStart(this.data).subscribe(function (data) { return _this.gameId = data['id']; });
        this._router.navigate(['/play', { queryParams: { id: this.gameId } }]);
    };
    StartComponent = __decorate([
        Component({
            selector: 'start-comp',
            templateUrl: './start.component.html',
            providers: [GameService]
        }),
        __metadata("design:paramtypes", [GameService, Router])
    ], StartComponent);
    return StartComponent;
}());
export { StartComponent };
//# sourceMappingURL=start.component.js.map