import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { StartGameView } from './shared/start-game.model';
import { StartGameService } from "./shared/start-game.service";
import { Observable } from "rxjs";

@Component({
  selector: 'start-game-comp',
  templateUrl: './start-game.component.html',
  styleUrls: ['./start-game.component.css'],
  providers:[StartGameService]
})

export class StartGameComponent implements OnInit{
  data: StartGameView;
  gameId: number;
  noNewPlayer: boolean;

  constructor(private gameService: StartGameService, private _router: Router) { }

  ngOnInit() {
    this.noNewPlayer = true;
    this.gameService.getStart().subscribe((data: StartGameView) => {
      this.data = data;      
    });
  }

  addPlayer() {
    this.noNewPlayer = false;
  }

  createNewPlayer() {
    this.data.players.push({ id: 0, name: this.data.newPlayerName });
  }

  submit() {
    this.gameService.postStart(this.data).subscribe((data: number) => {
      this.gameId = data;
    });
    let id = this.gameId;
    console.log(id);
    this._router.navigate(['/play', id]);
  }

}
