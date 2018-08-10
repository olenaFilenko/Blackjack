using BlackJack.Entities.Enums;
using Dapper.Contrib.Extensions;

namespace BlackJack.Entities.Models
{
    public class GamePlayer:BaseEntity
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public GameResult Result { get; set; }
        public int Points { get; set; }

        [Write(false)]
        public virtual Player Player { get; set; }
        [Write(false)]
        public virtual Game Game { get; set; }
    }
}