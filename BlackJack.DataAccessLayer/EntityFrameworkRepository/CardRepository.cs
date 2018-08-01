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
    public class CardRepository : ICardRepository
    {
        private BlackJackContext _context;

        public CardRepository(BlackJackContext context) {
            _context = context;
        }
        public async Task DeleteCard(int id)
        {
            Card card =await _context.Cards.FindAsync(id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }

        public async Task<Card> GetCardById(int id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            var cards = await (from c in _context.Cards select c).ToListAsync();
            return cards;
        }

        public async Task InsertCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCard(Card card)
        {
            _context.Entry(card).State = EntityState.Modified;
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