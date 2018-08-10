using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.Entities.Models;


namespace BlackJack.DataAccess.Interfaces
{
    public interface IGameRepository:IGenericRepository<Game>
    {
        Task<IEnumerable<Game>> GetAllGamesIncludeGamePlyerEntity();
    }
}
