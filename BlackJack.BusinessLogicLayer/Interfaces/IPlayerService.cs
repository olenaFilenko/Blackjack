using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.PlayerServiceViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IPlayerService
    {
        Task AddPlayer(AddPlayerView addPlayerViewModel );
        Task<IEnumerable<GetDealersView>> GetDealers();
        Task<IEnumerable<GetDealersView>> GetPlayers();
        Task AddPlayer(RequestAddPlayerView addPlayerView);
    }
}
