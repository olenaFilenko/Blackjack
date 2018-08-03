using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using System.Data.Entity;
using BlackJack.DataAccess.EntityFrameworkRepository;
using System.Threading.Tasks;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.DataAccess.EntityFrameworkRepository
{
    public class PlayerRepository : IPlayerRepository
    {
        private BlackJackContext _context;

        public PlayerRepository(BlackJackContext context) {
            _context = context;
        }

        public async Task DeletePlayer(int id)
        {
            Player player =await _context.Players.FindAsync(id);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
        
        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
               
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var pl=await (from p in _context.Players where p.RoleId==Role.Player select p).ToListAsync();
            return pl;
            
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task InsertPlayer(Player player)
        {
            _context.Players.Add(player);
            await  _context.SaveChangesAsync();
        }

        public async Task UpdatePlayer(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Player>> GetDealers()
        {
            var pl = await(from p in _context.Players where p.RoleId==Role.Dealer select p).ToListAsync();
            return pl;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var pl = await (from p in _context.Players select p).ToListAsync();
            return pl;
        }

        public async Task<IEnumerable<Player>> GetBots()
        {
            var pl = await(from p in _context.Players where p.RoleId == Role.Bot select p).ToListAsync();
            return pl;
        }

        public Task<IEnumerable<Player>> All()
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Player entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Add(Player entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Player entity)
        {
            throw new NotImplementedException();
        }
    }
}