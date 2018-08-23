import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { GameResultComponent } from "./game-result.component";
import { GameResultRoutingModule } from "./game-result-routing.module";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  imports: [SharedModule, HttpClientModule, GameResultRoutingModule],
  declarations: [GameResultComponent]
})

export class GameResultModule {}
