using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities.Models;

namespace BlackJack.DataAccess.DapperRepositories
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        private string _connectionString;
        
        public CardRepository(string connectionString):base(connectionString)
        {
            _connectionString = connectionString;
        }
        
    }
}
