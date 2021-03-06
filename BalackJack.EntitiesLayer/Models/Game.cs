﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJack.Entities.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Write(false)]
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        
    }
}