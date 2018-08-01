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
        Task<int> StartGame(StartGameViewModel startGame);
        Task<IEnumerable<GetAllPlayersViewModel>> GetAllPlayers();
        Task<IEnumerable<GetAllDealersViewModel>> GetAllDealers();
        Task<IEnumerable<ShowGamePlayerViewModel>> GetAllGamePlayersByGameId(int id);
        Task<IEnumerable<ShowGamePlayerViewModel>> GetAllGamePlayersWithoutDealerByGameId(int id);
        Task<ShowGamePlayerViewModel> GetGameDealerByGameId(int id);
        Task<IEnumerable<GetAllGamesViewModel>> GetAllGames();
        Task<ShowGameViewModel> ShowGame(int id);
        Task StartFirstGameRound(int id);
        Task StartGameRound(int gamePlayerId, Card passCard);
        Task FinishGame(ShowGameViewModel showGame);
        Task Enough(int id);
        Task More(int id);
        Task Delete(int id);
        Task Save();
    }
}
