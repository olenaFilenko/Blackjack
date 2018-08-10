using BlackJack.Entities.Models;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.DataAccess.EntityFrameworkRepository
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        private BlackJackContext _context;

        public CardRepository(BlackJackContext context):base(context)
        {
            _context = context;
        }
        
    }
}