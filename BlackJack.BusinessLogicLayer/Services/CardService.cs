using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Iterfaces;
//using BlackJack.DataAccess.EntityFrameworkRepository;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.CardServiceViewModel;
using BlackJack.DataAccess.DapperRepositories;

namespace BlackJack.BusinessLogic.Services
{
    public class CardService : ICardService
    {
        private Random _rnd;
        //BlackJackContext _context;
        ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository) {
            _rnd = new Random();
            //_context = new BlackJackContext();
            _cardRepository = cardRepository;
        }
        public async Task Add(AddCardViewModel addCard)
        {
            Card card = new Card();
            card.Name = addCard.Name;
            card.Value = addCard.Value;
            try
            {
                await _cardRepository.InsertCard(card);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public async Task<IEnumerable<GetAllCardsViewModel>> GetAllCards()
        {
            List<GetAllCardsViewModel> allCards = new List<GetAllCardsViewModel>();
            var cards = await _cardRepository.GetCards();
            foreach (Card c in cards)
            {
                GetAllCardsViewModel allCardsItem = new GetAllCardsViewModel();
                allCardsItem.Id = c.Id;
                allCardsItem.Name = c.Name;
                allCardsItem.Value = c.Value;
                allCards.Add(allCardsItem);
            }
            return allCards;

        }

        public async Task<GetCardByIdViewModel> GetCardById(int id)
        {
            GetCardByIdViewModel getCard = new GetCardByIdViewModel();
            Card card = await _cardRepository.GetCardById(id);
            getCard.Id = card.Id;
            getCard.Name = card.Name;
            getCard.Value = card.Value;
            return getCard;
        }

        public async Task RemoveCard(int id)
        {
            await _cardRepository.DeleteCard(id);
        }

        public async Task Save()
        {
            await _cardRepository.Save();
        }

        public async Task Update(UpdateCardViewModel updateCard)
        {
            Card card = new Card();
            card.Id = updateCard.Id;
            card.Name = updateCard.Name;
            card.Value = updateCard.Value;
            await _cardRepository.UpdateCard(card);

        }

        public async Task<UpdateCardViewModel> Update(int id)
        {
            UpdateCardViewModel getCard = new UpdateCardViewModel();
            Card card = await _cardRepository.GetCardById(id);
            getCard.Id = card.Id;
            getCard.Name = card.Name;
            getCard.Value = card.Value;
            return getCard;
        }

        public async Task<PassCardViewModel> PassCard()
        {
            PassCardViewModel passCard = new PassCardViewModel();
            var cards = await _cardRepository.GetCards();
            int cardNumber = cards.Count<Card>();
            Card[] cardDeck = new Card[cardNumber];
            int i = 0;
            foreach (Card c in cards)
            {
                cardDeck[i] = c;
                i++;
            }
            int cardRandomIndex = _rnd.Next(0, (cardNumber - 1));
            Card card = cardDeck[cardRandomIndex];
            passCard.Name = card.Name;
            passCard.Value = card.Value;
            return passCard;
        }
    }
}
