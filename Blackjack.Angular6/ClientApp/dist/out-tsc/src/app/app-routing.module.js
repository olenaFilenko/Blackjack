var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
var routes = [
    { path: 'history', loadChildren: './history-of-games/history-of-games.module#HistoryModule' },
    { path: 'result/:id', loadChildren: './game-result/game-result.module#GameResultModule' },
    { path: 'play/:id', loadChildren: './play-game/play-game.module#PlayGameModule' },
    { path: 'start', loadChildren: './start-game/start-game.module#StartGameModule' },
    { path: '', redirectTo: '', pathMatch: 'full' },
    { path: '**', loadChildren: './error/error.module#ErrorModule' }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        NgModule({
            imports: [
                RouterModule.forRoot(routes)
            ],
            exports: [RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map