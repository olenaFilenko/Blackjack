import { GamePlayerPlayGameViewItem } from "./game-player-play-game-item.model";

export interface PlayGameView {
  id: number;
  name: string;
  creationDate: Date;
  dealer: GamePlayerPlayGameViewItem;
  players: GamePlayerPlayGameViewItem[];
}
