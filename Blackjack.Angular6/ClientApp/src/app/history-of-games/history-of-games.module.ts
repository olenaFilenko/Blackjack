import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

import { HistoryComponent } from "./history-of-games.component";
import { HistoryRoutingModule } from "./history-of-games-routing.module";


@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    HistoryRoutingModule],
  declarations: [HistoryComponent],
  providers: []
})

export class HistoryModule {}
