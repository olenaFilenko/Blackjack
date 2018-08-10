using System.Collections.Generic;
using BlackJack.Entities.Enums;
using Dapper.Contrib.Extensions;

namespace BlackJack.Entities.Models
{
    public class Player:BaseEntity
    {
        public string Name { get; set; }
        public Role RoleId { get; set; }

        [Write(false)]
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }

    }
}