import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HistoryComponent } from './history-of-games/history-of-games.component';
import { GameResultComponent } from './game-result/game-result.component';
import { PlayGameComponent } from './play-game/play-game.component';
import { StartGameComponent } from './start-game/start-game.component';
import { ErrorComponent } from './error/error.component';
import { CommonModule } from '@angular/common';
import { GameResultModule } from './game-result/game-result.module';
import { StartGameModule } from './start-game/start-game.module';
import { PlayGameModule } from './play-game/play-game.module';
import { HistoryModule } from './history-of-games/history-of-games.module';

const routes: Routes = [
  { path: 'history', component: HistoryComponent },
  { path: 'result/:id', component: GameResultComponent },
  { path: 'play/:id', component: PlayGameComponent },
  { path: 'start', component: StartGameComponent },
  { path: '', redirectTo: 'history', pathMatch: 'full' },
  { path: '**', component: ErrorComponent }
];

@NgModule({
  imports: [CommonModule,
    GameResultModule,
    StartGameModule,
    PlayGameModule,
    HistoryModule,
    RouterModule.forRoot(routes)],
  declarations: [ErrorComponent],
  exports: [RouterModule]
})
export class AppRoutingModule { }
