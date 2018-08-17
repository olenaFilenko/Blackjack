import { PlayerStartGameViewItem } from './playerStartGameViewItem';

export class StartGameView {
    name: string;
    dealers: PlayerStartGameViewItem[];
    players: PlayerStartGameViewItem[];
    playerId: number;
    newPlayerName: string;
    botsNumber: number;

}