import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { HistoryComponent } from './history-of-games/history-of-games.component';
import { GameResultModule } from './game-result/game-result.module';
import { StartGameModule } from './start-game/start-game.module';
import { PlayGameModule } from './play-game/play-game.module';
import { HistoryModule } from './history-of-games/history-of-games.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    GameResultModule,
    StartGameModule,
    PlayGameModule,
    HistoryModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
