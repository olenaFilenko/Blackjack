using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.PlayerServiceViewModels
{
    public class GetPlayersView
    {
        public List<GetPlayersViewItem> Players { get; set; }

        public GetPlayersView()
        {
            Players = new List<GetPlayersViewItem>();
        }
    }
}
