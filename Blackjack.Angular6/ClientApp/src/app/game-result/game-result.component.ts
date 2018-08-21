import { Component, OnInit } from '@angular/core';
import { DetailsGameView } from './shared/game-result.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ResultGameService } from './shared/game-result.service';

@Component({
  selector: 'game-result-comp',
  templateUrl: './game-result.component.html',
  styleUrls: ['./game-result.component.css'],
  providers: [ResultGameService]
})

export class GameResultComponent implements OnInit {
  data: DetailsGameView;
  id: number;

  constructor(private gameService: ResultGameService, private _Activatedroute: ActivatedRoute, private _router: Router) { }

  back() {
    this._router.navigate(['/history']);
  }

  ngOnInit() {
    this._Activatedroute.params.subscribe(params => { this.id = params['id']; });
    this.gameService.getDetails(this.id).subscribe((data: DetailsGameView) => {
      this.data = data;
   });
  }
}
