import { Component } from '@angular/core';
import { PlayGameView } from '../shared/Models/playGameView';
import { GameService } from '../shared/Service/game.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'play-comp',
    templateUrl: './play.component.html',
    styleUrls:['./play.component.css'],
    providers: [GameService]

})

export class PlayComponent {
    data: PlayGameView;

    constructor(private gameService: GameService, private _Activatedroute: ActivatedRoute) {}

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