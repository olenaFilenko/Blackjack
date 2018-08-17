import { NgModule } from "@angular/core";
import { PlayGameComponent } from "./play-game.component";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';

@NgModule({

  imports: [FormsModule, CommonModule, HttpClientModule],
  declarations: [PlayGameComponent],
})

export class PlayGameModule {}
