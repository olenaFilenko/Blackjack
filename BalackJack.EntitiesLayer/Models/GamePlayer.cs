using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJack.Entities.Models
{
    public class GamePlayer
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string Result { get; set; }

        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
    }
}