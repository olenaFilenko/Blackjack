using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRepository:IGenericRepository<Player>
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<IEnumerable<Player>> GetDealers();
        Task<IEnumerable<Player>> GetBots();       
    }
}
