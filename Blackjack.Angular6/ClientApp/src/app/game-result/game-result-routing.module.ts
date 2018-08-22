import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GameResultComponent } from './game-result.component';

const routes: Routes = [
  {
    path: '',
    component: GameResultComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class GameResultRoutingModule { }
