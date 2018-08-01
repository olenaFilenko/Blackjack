using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.CardServiceViewModel;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface ICardService
    {
        Task Add(AddCardViewModel addCard);
        Task<IEnumerable<GetAllCardsViewModel>> GetAllCards();
        Task<GetCardByIdViewModel> GetCardById(int id);
        Task RemoveCard(int id);
        Task Update(UpdateCardViewModel updateCard);
        Task<UpdateCardViewModel> Update(int id);
        Task<PassCardViewModel> PassCard();
        Task Save();

    }
}
