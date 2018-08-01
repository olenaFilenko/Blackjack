using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.GameServiceViewModels;
using BlackJack.ViewModels.CardServiceViewModel;
using BlackJack.ViewModels.GamePlayerServiceViewModels;
using BlackJack.ViewModels.PlayerServiceViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        Task StartGame(StartGameViewModel startGame);
        Task SetGame(SetGameViewModel setGame);
        Task<SetGameViewModel> SetGame(int id);
        Task<IEnumerable<GetAllGamesViewModel>> GetAllGames();
        Task<ShowGameViewModel> ShowGame(int id);
        Task StartGameRound(int gamePlayerId, PassCardViewModel passCard, int playerId);
        Task FinishFirstGameRound(ShowGameViewModel showGame);
        Task CheckGameRoundResults(ShowGamePlayerViewModel showGamePlayer);
        Task Enough(int id);
        Task CalculateGameResult(ShowGamePlayerViewModel player, GetPlayerByIdViewModel dealer);
        Task FinishGame(ShowGamePlayerViewModel  player);
        Task Delete(int id);
        Task Save();
    }
}
