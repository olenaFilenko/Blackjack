var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './AppComponent/app.component';
import { HistoryComponent } from './HistoryComponent/history.component';
import { StartComponent } from './StartComponent/start.component';
import { PlayComponent } from './PlayComponent/play.component';
import { ResultComponent } from './ResultComponent/result.component';
import { ErrorComponent } from './ErrorComponent/error.component';
import { GameService } from './shared/Service/game.service';
import { appRoutes } from './app.routing';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            imports: [BrowserModule, ReactiveFormsModule, HttpModule, RouterModule.forRoot(appRoutes)],
            declarations: [AppComponent, HistoryComponent, StartComponent, PlayComponent, ResultComponent, ErrorComponent],
            providers: [GameService, { provide: APP_BASE_HREF, useValue: '/' }],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map