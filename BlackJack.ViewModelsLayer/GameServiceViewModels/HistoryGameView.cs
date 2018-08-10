using System.Collections.Generic;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class HistoryGameView
    {
        public List<HistoryGameViewItem> Games { get; set; }

        public HistoryGameView()
        {
            Games = new List<HistoryGameViewItem>();
        }
    }
}
