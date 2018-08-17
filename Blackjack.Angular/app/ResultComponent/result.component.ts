import { Component } from '@angular/core';
import { DetailsGameView } from '../shared/Models/detailsGameView';
import { GameService } from '../shared/Service/game.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'result-comp',
    templateUrl: './result.component.html',
    styleUrls:['./result.component.css'],
    providers: [GameService]
})

export class ResultComponent {
    data: DetailsGameView;
    id: number;
    
    constructor(private gameService: GameService, private _Activatedroute: ActivatedRoute) {}

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