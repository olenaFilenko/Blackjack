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
var HistoryComponent = /** @class */ (function () {
    function HistoryComponent(gameService) {
        this.gameService = gameService;
    }
    HistoryComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.gameService.getHistory().subscribe(function (data) { return _this.data.games = data['games']; });
    };
    HistoryComponent = __decorate([
        Component({
            selector: 'history-comp',
            templateUrl: './history.component.html',
            styleUrls: ['./history.component.css'],
            providers: [GameService]
        }),
        __metadata("design:paramtypes", [GameService])
    ], HistoryComponent);
    return HistoryComponent;
}());
export { HistoryComponent };
//# sourceMappingURL=history.component.js.map