
namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class GamePlayerPlayGameViewItem
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string Result { get; set; }
    }
}
