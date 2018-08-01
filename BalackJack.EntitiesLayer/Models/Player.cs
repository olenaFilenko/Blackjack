using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.Entities.Enums;
using Dapper.Contrib.Extensions;

namespace BlackJack.Entities.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role RoleId { get; set; }

        [Write(false)]
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }

    }
}