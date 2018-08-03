using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using System.Data.Entity;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGamePlayerRepository:IGenericRepository<GamePlayer>
    {
        Task<IEnumerable<GamePlayer>> GetGamePlayersByGameId(int id);
    }
}
