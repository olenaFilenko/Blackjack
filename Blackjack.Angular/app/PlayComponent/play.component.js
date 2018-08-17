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
import { ActivatedRoute } from '@angular/router';
var PlayComponent = /** @class */ (function () {
    function PlayComponent(gameService, _Activatedroute) {
        this.gameService = gameService;
        this._Activatedroute = _Activatedroute;
    }
    PlayComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._Activatedroute.params.subscribe(function (params) { _this.data.id = params['id']; });
        this.gameService.getPlay(this.data.id).subscribe(function (data) {
            _this.data.name = data['name'];
            _this.data.creationDate = data['creationDate'];
            _this.data.dealer = data['dealer'];
            _this.data.players = data['players'];
        });
    };
    PlayComponent.prototype.More = function () {
        var _this = this;
        this.gameService.postMore(this.data.id);
        this.gameService.getPlay(this.data.id).subscribe(function (data) {
            _this.data.dealer = data['dealer'];
            _this.data.players = data['players'];
        });
    };
    PlayComponent.prototype.Enough = function () {
        var _this = this;
        this.gameService.postEnough(this.data.id);
        this.gameService.getPlay(this.data.id).subscribe(function (data) {
            _this.data.dealer = data['dealer'];
            _this.data.players = data['players'];
        });
    };
    PlayComponent = __decorate([
        Component({
            selector: 'play-comp',
            templateUrl: './play.component.html',
            styleUrls: ['./play.component.css'],
            providers: [GameService]
        }),
        __metadata("design:paramtypes", [GameService, ActivatedRoute])
    ], PlayComponent);
    return PlayComponent;
}());
export { PlayComponent };
//# sourceMappingURL=play.component.js.map