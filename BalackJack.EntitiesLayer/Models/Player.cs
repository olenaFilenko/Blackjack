using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.Entities.Enums;

namespace BlackJack.Entities.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public Role RoleId { get; set; }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }

    }
}