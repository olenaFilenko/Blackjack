using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<GamePlayer> GetGameDealerByGameId(int id)
        {
            GamePlayer gamePlayer = await (from gp in _context.GamePlayers where gp.GameId == id && gp.Player.RoleId == Role.Dealer select gp).FirstOrDefaultAsync();
            return gamePlayer;
        }

        public Task<GamePlayer> GetGameDealerByGameIdIncludePlayerEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GamePlayer> GetGamePlayerByGameId(int id)
        {
            GamePlayer gamePlayer = await(from gp in _context.GamePlayers where gp.GameId == id && gp.Player.RoleId == Role.Player select gp).FirstOrDefaultAsync();
            return gamePlayer;
        }

        public Task<GamePlayer> GetGamePlayerByGameIdIncludePlayerEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersByGameId(int id)
        {
            var gamePlayers =await (from gp in _context.GamePlayers where gp.GameId == id select gp).ToListAsync();
            return gamePlayers;
        }

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersByGameIdIncludePlayerEntity(int id)
        {
            var gamePlayers = await(from gp in _context.GamePlayers where gp.GameId==id select gp).Include(gp => gp.Player).ToListAsync();
            return gamePlayers;
        }

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersIncludePlayerEntity()
        {
            var gamePlayers = await (from gp in _context.GamePlayers select gp).Include(gp => gp.Player).ToListAsync();
            return gamePlayers;
        }

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersWithoutDealerByGameId(int id)
        {
            var gamePlayers = await(from gp in _context.GamePlayers where gp.GameId == id && gp.Player.RoleId!=Role.Dealer select gp).ToListAsync();
            return gamePlayers;
        }
    }
}