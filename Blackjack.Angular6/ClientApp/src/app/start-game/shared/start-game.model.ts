import { PlayerStartGameViewItem } from "./player-start-game-item.model";

export interface StartGameView {
  name: string;
  dealers: PlayerStartGameViewItem[];
  players: PlayerStartGameViewItem[];
  dealerId: number;
  playerId: number;
  newPlayerName: string;
  botsNumber: number;

}
