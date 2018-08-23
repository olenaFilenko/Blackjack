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
import { HistoryService } from './shared/history.service';
import { Router } from '@angular/router';
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
        Component({
            selector: 'history-comp',
            templateUrl: './history-of-games.component.html',
            styleUrls: ['./history-of-games.component.css'],
            providers: [HistoryService]
        }),
        __metadata("design:paramtypes", [HistoryService, Router])
    ], HistoryComponent);
    return HistoryComponent;
}());
export { HistoryComponent };
//# sourceMappingURL=history-of-games.component.js.map