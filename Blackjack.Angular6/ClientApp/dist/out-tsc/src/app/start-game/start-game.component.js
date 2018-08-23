var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { StartGameService } from "./shared/start-game.service";
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
        Component({
            selector: 'start-game-comp',
            templateUrl: './start-game.component.html',
            styleUrls: ['./start-game.component.css'],
            providers: [StartGameService]
        }),
        __metadata("design:paramtypes", [StartGameService, Router])
    ], StartGameComponent);
    return StartGameComponent;
}());
export { StartGameComponent };
//# sourceMappingURL=start-game.component.js.map