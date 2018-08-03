using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class StartGameView
    {
        [Display(Name="Enter game name")]
        public string Name { get; set; }

        public List<PlayerStartGameViewItem> Dealers{ get; set; }

        [Display(Name="Choose dealer")]
        public int DealerId { get; set; }

        public List<PlayerStartGameViewItem> Players { get; set; }

        [Display(Name = "Choose player")]
        public int PlayerId { get; set; }

        [Range(0,5,ErrorMessage ="The bots number shoud be between {0} and {1}")]
        [Display(Name ="Number of bots")]
        public int BotsNumber { get; set; }
    }
}
