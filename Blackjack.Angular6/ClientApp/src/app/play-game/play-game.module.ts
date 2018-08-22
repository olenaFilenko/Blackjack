import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';

import { PlayGameRoutingModule } from "./play-game-routing.module";
import { PlayGameComponent } from "./play-game.component";

@NgModule({

  imports: [FormsModule, CommonModule, HttpClientModule, PlayGameRoutingModule],
  declarations: [PlayGameComponent],
})

export class PlayGameModule {}
