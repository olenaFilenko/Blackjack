using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;


namespace BlackJack.DataAccess.Iterfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGames();
        Task<Game> GetGameById(int id);
        Task InsertGame(Game game);
        Task DeleteGame(int id);
        Task UpdateGame(Game game);
        Task Save();
    }
}
