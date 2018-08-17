import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';

import { StartGameComponent } from "./start-game.component";

@NgModule({
  imports: [FormsModule, CommonModule, HttpClientModule],
  declarations: [StartGameComponent]
})

export class StartGameModule {}
