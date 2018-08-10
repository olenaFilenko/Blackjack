using System;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class HistoryGameViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DealerName { get; set; }
        public string PlayerName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
