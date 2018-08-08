﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class DetailsGameView
    {
        public int Id { get; set; }
        [Display(Name ="Game's name")]
        public string Name { get; set; }
        [Display(Name ="Dealer")]
        public GamePlayerDetailsGameViewItem Dealer { get; set; }
        public List<GamePlayerDetailsGameViewItem> Players { get; set; }
    }
}