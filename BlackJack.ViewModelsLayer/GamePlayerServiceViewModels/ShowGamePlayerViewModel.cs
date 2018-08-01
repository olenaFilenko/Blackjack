using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.GamePlayerServiceViewModels
{
    public class ShowGamePlayerViewModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; } //player's id
        public string Name { get; set; }
        public int Points { get; set; }
        public string Result { get; set; }
    }
}
