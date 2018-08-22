import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';

import { StartGameComponent } from "./start-game.component";
import { StartGameRoutingModule } from "./start-game-routing.module";

@NgModule({
  imports: [FormsModule, CommonModule, HttpClientModule, StartGameRoutingModule],
  declarations: [StartGameComponent]
})

export class StartGameModule {}
