import { GamePlayerDetailsGameViewItem } from './gamePlayerDetailsGameViewItem';

export class DetailsGameView {
    id: number;
    name: string;
    creationDate: Date;
    dealer: GamePlayerDetailsGameViewItem;
    players: GamePlayerDetailsGameViewItem[];
}