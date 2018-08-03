using System.Threading.Tasks;
using BlackJack.ViewModels.PlayerServiceViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IPlayerService
    {
        Task AddPlayer(AddPlayerView addPlayerViewModel );
    }
}
