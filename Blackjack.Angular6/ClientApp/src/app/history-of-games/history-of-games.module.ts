import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { HistoryComponent } from "./history-of-games.component";
import { HttpClientModule } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { AppRoutingModule } from "../app-routing.module";

@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule],
  declarations: [HistoryComponent]
 
})

export class HistoryModule {}
