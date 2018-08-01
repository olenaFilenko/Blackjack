using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;


namespace BlackJack.DataAccess.Iterfaces
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetCards();
        Task<Card> GetCardById(int id);
        Task InsertCard(Card card);
        Task DeleteCard(int id);
        Task UpdateCard(Card card);
        Task Save();
    }
}
