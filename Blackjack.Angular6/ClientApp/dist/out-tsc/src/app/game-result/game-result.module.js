var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { GameResultComponent } from "./game-result.component";
import { GameResultRoutingModule } from "./game-result-routing.module";
import { SharedModule } from "../shared/shared.module";
var GameResultModule = /** @class */ (function () {
    function GameResultModule() {
    }
    GameResultModule = __decorate([
        NgModule({
            imports: [SharedModule, HttpClientModule, GameResultRoutingModule],
            declarations: [GameResultComponent]
        })
    ], GameResultModule);
    return GameResultModule;
}());
export { GameResultModule };
//# sourceMappingURL=game-result.module.js.map