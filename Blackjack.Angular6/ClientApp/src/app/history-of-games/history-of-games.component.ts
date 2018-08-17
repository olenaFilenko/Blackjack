import { Component } from '@angular/core';
import { HistoryService } from './shared/history.service';
import { HistoryGameView } from './shared/history.model';
import { Router } from '@angular/router';

@Component({
  selector: 'history-comp',
  templateUrl: './history-of-games.component.html',
  styleUrls: ['./history-of-games.component.css'],
  providers: [HistoryService]
})
export class HistoryComponent {
  data: HistoryGameView;

  constructor(private gameService: HistoryService, private router: Router) { }

  showResults(id:number) {
    this.router.navigate(['/result', id]);
  }

  ngOnInit() {
    this.gameService.getHistory().subscribe(data => this.data.games = data['games']);
  }

  
}
