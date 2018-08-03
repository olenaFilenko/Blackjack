using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.PlayerServiceViewModels;

namespace BlackJack.BusinessLogic.Services
{
    public class PlayerService : IPlayerService
    {
        private IGenericRepository<Player> _playerRepository;        

        public PlayerService(IGenericRepository<Player> playerRepository) {           
            _playerRepository = playerRepository;
        }

        public async Task AddPlayer(AddPlayerView addPlayerViewModel)
        {
            Player player = new Player();
            player.Name = addPlayerViewModel.Name;
            player.RoleId = Role.Player;
            await _playerRepository.Add(player);
        }
        
    }
}
