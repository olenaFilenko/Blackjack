using System.Collections.Generic;
using System.Linq;
using BlackJack.Entities.Models;
using System.Data.Entity;
using BlackJack.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.EntityFrameworkRepository
{
    public class GameRepository :GenericRepository<Game>, IGameRepository
    {
        private BlackJackContext _context;

        public GameRepository(BlackJackContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllGamesIncludeGamePlyerEntity()
        {
            var result = await (from g in _context.Games select g).Include(g => g.GamePlayers).ToListAsync();
            return result;
        }
    }
}