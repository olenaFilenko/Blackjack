import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PlayGameView } from "./shared/play-game.model";
import { PlayGameService } from "./shared/play-game.service";

@Component({
  selector: 'play-game-comp',
  templateUrl: './play-game.component.html',
  styleUrls: ['./play-game.component.css'],
  providers: [PlayGameService]
})

export class PlayGameComponent implements OnInit {
  data: PlayGameView;
  id: number;

  constructor(private gameService: PlayGameService, private _Activatedroute: ActivatedRoute, private _router: Router) { }

  ngOnInit() {
    this._Activatedroute.params.subscribe(params => { this.id = params['id']; });
    this.gameService.getPlay(this.id).subscribe((data: PlayGameView) => {
      this.data = data;
    });
  }

  More() {
    this.gameService.postMore(this.data.id).subscribe(response => {
      this.gameService.getPlay(this.data.id).subscribe((data: PlayGameView) => {
        this.data.dealer = data['dealer'];
        this.data.players = data['players'];
      });
    });
    
  }

  Enough() {
    this.gameService.postEnough(this.data.id).subscribe(response => {
      let id = this.data.id;
      this._router.navigate(['/result', id]);
    });
  }

}
