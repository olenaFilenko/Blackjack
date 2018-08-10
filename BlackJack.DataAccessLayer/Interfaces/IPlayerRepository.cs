using System.Collections.Generic;
using System.Threading.Tasks;
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
