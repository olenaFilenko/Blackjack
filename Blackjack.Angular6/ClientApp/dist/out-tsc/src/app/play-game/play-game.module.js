var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { PlayGameRoutingModule } from "./play-game-routing.module";
import { PlayGameComponent } from "./play-game.component";
import { SharedModule } from "../shared/shared.module";
var PlayGameModule = /** @class */ (function () {
    function PlayGameModule() {
    }
    PlayGameModule = __decorate([
        NgModule({
            imports: [SharedModule, HttpClientModule, PlayGameRoutingModule],
            declarations: [PlayGameComponent],
        })
    ], PlayGameModule);
    return PlayGameModule;
}());
export { PlayGameModule };
//# sourceMappingURL=play-game.module.js.map