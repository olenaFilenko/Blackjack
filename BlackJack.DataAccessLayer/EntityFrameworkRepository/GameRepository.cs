using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using System.Data.Entity;
using BlackJack.DataAccess.Iterfaces;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.EntityFrameworkRepository
{
    public class GameRepository : IGameRepository
    {
        private BlackJackContext _context;

        public GameRepository(BlackJackContext context)
        {
            _context = context;
        }

        public async Task DeleteGame(int id)
        {
            Game game =await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Game>> GetGames()
        {
            var games =await (from g in _context.Games select g).ToListAsync();
            return games;
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task InsertGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGame(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
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

        
    }
}