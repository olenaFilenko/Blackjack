import { Component } from '@angular/core';
//import { HistoryGameView } from '../shared/Models/historyGameView';
//import { GameService } from '../shared/Service/game.service';

@Component({
  selector: 'history-comp',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css'],
  providers: [GameService]
})
export class HistoryComponent {
  data: HistoryGameView;

  constructor(private gameService: GameService) { }

  ngOnInit() {
    this.gameService.getHistory().subscribe(data => this.data.games = data['games']);
  }
}
