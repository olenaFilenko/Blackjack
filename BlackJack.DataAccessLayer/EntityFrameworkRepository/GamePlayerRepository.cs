using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using System.Data.Entity;
using BlackJack.DataAccess.Interfaces;
using System.Threading.Tasks;


namespace BlackJack.DataAccess.EntityFrameworkRepository
{
    public class GamePlayerRepository : GenericRepository<GamePlayer>, IGamePlayerRepository
    {
        private BlackJackContext _context;

        public GamePlayerRepository(BlackJackContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersByGameId(int id)
        {
            var gamePlayers =await (from gp in _context.GamePlayers where gp.GameId == id select gp).ToListAsync();
            return gamePlayers;
        }
    }
}