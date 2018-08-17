import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { PlayGameView } from "./shared/play-game.model";
import { PlayGameService } from "./shared/play-game.service";

@Component({
  selector: 'play-game-comp',
  template: './play-game.component.html',
  styleUrls: ['./play-game.component.css'],
  providers: [PlayGameService]
})

export class PlayGameComponent {
  data: PlayGameView;

  constructor(private gameService: PlayGameService, private _Activatedroute: ActivatedRoute) { }

  ngOnInit() {
    this._Activatedroute.params.subscribe(params => { this.data.id = params['id']; });
    this.gameService.getPlay(this.data.id).subscribe(data => {
      this.data.name = data['name'];
      this.data.creationDate = data['creationDate'];
      this.data.dealer = data['dealer'];
      this.data.players = data['players'];
    });
  }

  More() {
    this.gameService.postMore(this.data.id);
    this.gameService.getPlay(this.data.id).subscribe(data => {
      this.data.dealer = data['dealer'];
      this.data.players = data['players'];
    });
  }

  Enough() {
    this.gameService.postEnough(this.data.id);
    this.gameService.getPlay(this.data.id).subscribe(data => {
      this.data.dealer = data['dealer'];
      this.data.players = data['players'];
    });
  }

}
