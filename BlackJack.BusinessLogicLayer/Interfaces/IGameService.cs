using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.ViewModels.GameServiceViewModels;


namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        Task<StartGameView> Start();
        Task<int> Start(StartGameView startGameView);
        Task<PlayGameView> Play(int id);
        Task<IEnumerable<HistoryGameView>> History();
        Task<DetailsGameView> Details(int id);
        Task Enough(int id);
        Task More(int id);

    }
}
