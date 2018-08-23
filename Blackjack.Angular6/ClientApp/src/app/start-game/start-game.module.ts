import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { StartGameComponent } from "./start-game.component";
import { StartGameRoutingModule } from "./start-game-routing.module";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  imports: [SharedModule, HttpClientModule, StartGameRoutingModule],
  declarations: [StartGameComponent]
})

export class StartGameModule {}
