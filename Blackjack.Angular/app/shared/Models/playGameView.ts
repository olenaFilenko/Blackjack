import { GamePlayerPlayGameViewItem } from './gamePlayerPlayGameViewItem';

export class PlayGameView {
    id: number;
    name: string;
    creationDate: Date;
    dealer: GamePlayerPlayGameViewItem;
    players: GamePlayerPlayGameViewItem[];
}