using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class HistoryGameView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DealerName { get; set; }
        public string PlayerName { get; set; }
    }
}
