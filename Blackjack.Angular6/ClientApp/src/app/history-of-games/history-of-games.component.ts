import { Component, OnInit } from '@angular/core';
import { HistoryService } from './shared/history.service';
import { HistoryGameView } from './shared/history.model';
import { Router } from '@angular/router';

@Component({
  selector: 'history-comp',
  templateUrl: './history-of-games.component.html',
  styleUrls: ['./history-of-games.component.css'],
  providers: [HistoryService]
})

export class HistoryComponent implements OnInit {
  data: HistoryGameView;

  constructor(private gameService: HistoryService, private router: Router) { }

  ngOnInit() {
    this.gameService.getHistory().subscribe((data: HistoryGameView) => {
      this.data = data;
    });
  }
 
  showResults(id:number) {
    this.router.navigate(['/result', id]);
  }

  startGame() {
    this.router.navigate(['/start']);
  }

}
