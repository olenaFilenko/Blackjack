using System.Collections.Generic;
using System.Linq;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.DataAccess.EntityFrameworkRepository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        private BlackJackContext _context;

        public PlayerRepository(BlackJackContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetBots()
        {
            var bots = await(from b in _context.Players where b.RoleId == Role.Bot select b).ToListAsync();
            return bots;
        }

        public async Task<IEnumerable<Player>> GetDealers()
        {
            var dealers = await(from d in _context.Players where d.RoleId == Role.Dealer select d).ToListAsync();
            return dealers;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var players = await (from p in _context.Players where p.RoleId == Role.Player select p).ToListAsync();
            return players;
        }
    }
}