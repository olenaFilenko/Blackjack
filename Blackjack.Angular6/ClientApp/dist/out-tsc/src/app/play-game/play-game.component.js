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
import { ActivatedRoute, Router } from "@angular/router";
import { PlayGameService } from "./shared/play-game.service";
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
        Component({
            selector: 'play-game-comp',
            templateUrl: './play-game.component.html',
            styleUrls: ['./play-game.component.css'],
            providers: [PlayGameService]
        }),
        __metadata("design:paramtypes", [PlayGameService, ActivatedRoute, Router])
    ], PlayGameComponent);
    return PlayGameComponent;
}());
export { PlayGameComponent };
//# sourceMappingURL=play-game.component.js.map