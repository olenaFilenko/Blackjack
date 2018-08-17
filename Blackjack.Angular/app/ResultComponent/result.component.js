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
var ResultComponent = /** @class */ (function () {
    function ResultComponent(gameService, _Activatedroute) {
        this.gameService = gameService;
        this._Activatedroute = _Activatedroute;
    }
    ResultComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._Activatedroute.params.subscribe(function (params) { _this.id = params['id']; });
        this.gameService.getDetails(this.id).subscribe(function (data) {
            _this.data.name = data['name'];
            _this.data.dealer = data['dealer'];
            _this.data.creationDate = data['creationDate'];
            _this.data.players = data['players'];
        });
    };
    ResultComponent = __decorate([
        Component({
            selector: 'result-comp',
            templateUrl: './result.component.html',
            styleUrls: ['./result.component.css'],
            providers: [GameService]
        }),
        __metadata("design:paramtypes", [GameService, ActivatedRoute])
    ], ResultComponent);
    return ResultComponent;
}());
export { ResultComponent };
//# sourceMappingURL=result.component.js.map