import { Component } from '@angular/core';
import { DetailsGameView } from './shared/game-result.model';
import { ActivatedRoute } from '@angular/router';
import { ResultGameService } from './shared/game-result.service';

@Component({
  selector: 'game-result-comp',
  templateUrl: './game-result.component.html',
  styleUrls: ['./game-result.component.css'],
  providers: [ResultGameService]
})

export class GameResultComponent {
  data: DetailsGameView;
  id: number;

  constructor(private gameService: ResultGameService, private _Activatedroute: ActivatedRoute) { }

  ngOnInit() {
    this._Activatedroute.params.subscribe(params => { this.id = params['id']; });
    this.gameService.getDetails(this.id).subscribe(data => {
      this.data.name = data['name'];
      this.data.dealer = data['dealer'];
      this.data.creationDate = data['creationDate'];
      this.data.players = data['players'];
    });
  }
}
