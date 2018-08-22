import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PlayGameComponent } from './play-game.component';

const routes: Routes = [
  {
    path: '',
    component: PlayGameComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class PlayGameRoutingModule { }
