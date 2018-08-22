import { NgModule} from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'history', loadChildren: './history-of-games/history-of-games.module#HistoryModule' },
  { path: 'result/:id', loadChildren: './game-result/game-result.module#GameResultModule' },
  { path: 'play/:id', loadChildren: './play-game/play-game.module#PlayGameModule' },
  { path: 'start', loadChildren: './start-game/start-game.module#StartGameModule'},
  { path: '', redirectTo: '', pathMatch: 'full' },
  { path: '**', loadChildren: './error/error.module#ErrorModule'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {}
