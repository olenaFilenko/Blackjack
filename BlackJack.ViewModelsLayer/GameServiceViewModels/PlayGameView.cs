using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class PlayGameView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Created")]
        public DateTime CreationDate { get; set; }
        [Display(Name ="Game dealer")]
        public GamePlayerPlayGameViewItem Dealer { get; set; }
        public List<GamePlayerPlayGameViewItem> Players { get; set; }

        public PlayGameView()
        {
            Dealer = new GamePlayerPlayGameViewItem();
            Players = new List<GamePlayerPlayGameViewItem>();
        }
    }
}
