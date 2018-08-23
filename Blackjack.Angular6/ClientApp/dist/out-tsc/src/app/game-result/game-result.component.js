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
import { ActivatedRoute, Router } from '@angular/router';
import { ResultGameService } from './shared/game-result.service';
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
        Component({
            selector: 'game-result-comp',
            templateUrl: './game-result.component.html',
            styleUrls: ['./game-result.component.css'],
            providers: [ResultGameService]
        }),
        __metadata("design:paramtypes", [ResultGameService, ActivatedRoute, Router])
    ], GameResultComponent);
    return GameResultComponent;
}());
export { GameResultComponent };
//# sourceMappingURL=game-result.component.js.map