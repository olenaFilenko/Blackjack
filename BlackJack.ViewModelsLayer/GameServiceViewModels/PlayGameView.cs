using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class PlayGameView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Game dealer")]
        public GamePlayerPlayGameViewItem Dealer { get; set; }
        public List<GamePlayerPlayGameViewItem> Players { get; set; }
    }
}
