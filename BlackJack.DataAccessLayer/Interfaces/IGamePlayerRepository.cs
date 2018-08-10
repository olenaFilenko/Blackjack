using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.Entities.Models;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGamePlayerRepository:IGenericRepository<GamePlayer>
    {
        Task<IEnumerable<GamePlayer>> GetGamePlayersByGameId(int id);
        Task<IEnumerable<GamePlayer>> GetGamePlayersWithoutDealerByGameId(int id);
        Task<GamePlayer> GetGameDealerByGameId(int id);
        Task<GamePlayer> GetGamePlayerByGameId(int id);
        Task<IEnumerable<GamePlayer>> GetGamePlayersIncludePlayerEntity();
        Task<IEnumerable<GamePlayer>> GetGamePlayersByGameIdIncludePlayerEntity(int id);
        Task<GamePlayer> GetGamePlayerByGameIdIncludePlayerEntity(int id);
        Task<GamePlayer> GetGameDealerByGameIdIncludePlayerEntity(int id);
    }
}
