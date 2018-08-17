import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';
import { GameResultComponent } from "./game-result.component";

@NgModule({
  imports: [CommonModule, HttpClientModule, FormsModule],
  declarations: [GameResultComponent]
})

export class GameResultModule {}
