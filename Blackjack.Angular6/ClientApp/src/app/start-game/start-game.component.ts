import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { StartGameView } from './shared/start-game.model';
import { Observable } from "rxjs";

import { StartGameService } from "./shared/start-game.service";

@Component({
  selector: 'start-game-comp',
  templateUrl: './start-game.component.html',
  styleUrls: ['./start-game.component.css'],
  providers:[StartGameService]
})

export class StartGameComponent implements OnInit{
  data: StartGameView;
  gameId: string;
  noNewPlayer: boolean;
  submitted: boolean;

  constructor(private gameService: StartGameService, private _router: Router) { }

  ngOnInit() {
    this.noNewPlayer = true;
    this.submitted = false;
    this.gameService.getStart().subscribe((data: StartGameView) => {
      this.data = data;      
    });
  }

  addPlayer() {
    this.noNewPlayer = false;
    this.data.playerId = 0;
  }

  onSubmit() {
      this.gameService.postStart(this.data).subscribe(response => {
      let id = response;      
      this._router.navigate(['/play', id]);
    });
  }

}
