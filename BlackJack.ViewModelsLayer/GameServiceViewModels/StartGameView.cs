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
        public int? DealerId { get; set; }

        public List<PlayerStartGameViewItem> Players { get; set; }

        [Display(Name = "Choose player")]
        public int? PlayerId { get; set; }

        public string NewPlayerName { get; set; }

        [Range(0, 5,
            ErrorMessage ="{0} shoud be between {1} and {2}")]
        [Display(Name ="Number of bots")]
        public int BotsNumber { get; set; }

        public StartGameView()
        {
            Dealers = new List<PlayerStartGameViewItem>();
            Players = new List<PlayerStartGameViewItem>();
        }


    }
}
