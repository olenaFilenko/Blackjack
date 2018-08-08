using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class HistoryGameView
    {
        public List<HistoryGameViewItem> Games { get; set; }
        public PageInfoHistoryViewItem PageInfo { get; set; }
    }
}
