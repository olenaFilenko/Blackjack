import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { PlayGameRoutingModule } from "./play-game-routing.module";
import { PlayGameComponent } from "./play-game.component";
import { SharedModule } from "../shared/shared.module";

@NgModule({

  imports: [SharedModule, HttpClientModule, PlayGameRoutingModule],
  declarations: [PlayGameComponent],
})

export class PlayGameModule {}
