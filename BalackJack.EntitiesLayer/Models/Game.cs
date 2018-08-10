using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace BlackJack.Entities.Models
{
    public class Game:BaseEntity
    {
        public string Name { get; set; }
        [Write(false)]
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        
    }
}