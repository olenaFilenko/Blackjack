using BalackJack.Entities.Enums;

namespace BlackJack.Entities.Models
{
    public class Card:BaseEntity
    {
        public CardName CardNameId { get; set; }
        public Suit SuitId { get; set; }
        public int Value { get; set; }
    }
}