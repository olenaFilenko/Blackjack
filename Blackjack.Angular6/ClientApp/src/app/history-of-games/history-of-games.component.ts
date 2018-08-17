import { Component } from '@angular/core';
import { HistoryService } from './shared/history.service';
import { HistoryGameView } from './shared/history.model';

@Component({
  selector: 'history-comp',
  templateUrl: './history-of-games.component.html',
  styleUrls: ['./history-of-games.component.css'],
  providers: [HistoryService]
})
export class HistoryComponent {
  data: HistoryGameView;

  constructor(private gameService: HistoryService) { }

  ngOnInit() {
    this.gameService.getHistory().subscribe(data => this.data.games = data['games']);
  }
}
