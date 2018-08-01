using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper.Contrib.Extensions;

namespace BlackJack.Entities.Models
{
    public class GamePlayer
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string Result { get; set; }
        public int Points { get; set; }

        [Write(false)]
        public virtual Player Player { get; set; }
        [Write(false)]
        public virtual Game Game { get; set; }
    }
}