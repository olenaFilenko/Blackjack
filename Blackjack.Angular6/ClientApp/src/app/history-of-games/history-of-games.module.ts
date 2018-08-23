import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { HistoryComponent } from "./history-of-games.component";
import { HistoryRoutingModule } from "./history-of-games-routing.module";
import { SharedModule } from "../shared/shared.module";


@NgModule({
  imports: [
    SharedModule,
    HttpClientModule,
    HistoryRoutingModule],
  declarations: [HistoryComponent],
  providers: []
})

export class HistoryModule {}
