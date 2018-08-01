using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class GetAllGamesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SetParametrsStatus { get; set; }
        public string Dealer { get; set; }
        public string Player { get; set; }
        public int BotsNumber { get; set; }
    }
}
