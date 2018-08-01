using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;

namespace BlackJack.DataAccess.Iterfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<IEnumerable<Player>> GetPlayers();
        Task<IEnumerable<Player>> GetDealers();
        Task<IEnumerable<Player>> GetBots();
        Task<Player> GetPlayerById(int id);
        Task InsertPlayer(Player player);
        Task DeletePlayer(int id);
        Task UpdatePlayer(Player player);
        Task Save();
    }
}
