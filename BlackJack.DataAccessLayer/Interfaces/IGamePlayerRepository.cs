using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using System.Data.Entity;

namespace BlackJack.DataAccess.Iterfaces
{
    public interface IGamePlayerRepository
    {
        Task<IEnumerable<GamePlayer>> GetGamePlayers();
        Task<IEnumerable<GamePlayer>> GetGamePlayersByGameId(int id);
        Task<IEnumerable<GamePlayer>> GetGamePlayersWithoutDealerByGameId(int id);
        Task<GamePlayer> GetGameDealerByGameId(int id);
        Task<GamePlayer> GetGamePlayerById(int id);
        Task InsertGamePlayer(GamePlayer player);
        Task DeleteGamePlayer(int id);
        Task UpdateGamePlayer(GamePlayer player);
        Task Save();
    }
}
