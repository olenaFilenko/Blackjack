using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.PlayerServiceViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IPlayerService
    {
        Task AddPlayer(AddPlayerView addPlayerViewModel );
        Task<GetDealersView> GetDealers();
        Task<GetPlayersView> GetPlayers();
        Task AddPlayer(RequestAddPlayerView addPlayerView);
    }
}
