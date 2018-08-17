import { Component } from '@angular/core';
import { StartGameView } from '../shared/Models/startGameView'
import { GameService } from '../shared/Service/game.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PlayerStartGameViewItem } from '../shared/Models/playerStartGameViewItem';

@Component({
    selector: 'start-comp',
    templateUrl: './start.component.html',
    providers: [GameService]
})

export class StartComponent {
    data: StartGameView;
    gameId: number;
    noNewPlayer: boolean;

    constructor(private gameService: GameService, private _router: Router,) { }

    ngOnInit() {
        this.noNewPlayer = true;
        this.gameService.getStart().subscribe(data => {
            this.data.dealers = data['dealers'];
            this.data.players = data['players'];
        });
    }

    addPlayer() {
        this.noNewPlayer = false;
    }

    createNewPlayer() {
        this.data.players.push({ id: 0, name: this.data.newPlayerName });
    }

    submit() {
        this.gameService.postStart(this.data).subscribe(data => this.gameId = data['id']);
        this._router.navigate(['/play', { queryParams: { id: this.gameId } }]);
    }
}