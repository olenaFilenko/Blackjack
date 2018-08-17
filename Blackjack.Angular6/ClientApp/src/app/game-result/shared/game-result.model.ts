import { GamePlayerDetailsGameViewItem } from "./game-player-game-result-item.model";

export interface DetailsGameView {
  id: number;
  name: string;
  creationDate: Date;
  dealer: GamePlayerDetailsGameViewItem;
  players: GamePlayerDetailsGameViewItem[];
}
