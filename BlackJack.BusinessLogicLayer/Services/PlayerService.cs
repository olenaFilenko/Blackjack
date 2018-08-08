using System.Collections.Generic;
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
        private IPlayerRepository _playerRepository;        

        public PlayerService(IPlayerRepository playerRepository) {           
            _playerRepository = playerRepository;
        }

        public async Task AddPlayer(AddPlayerView addPlayerViewModel)
        {
            Player player = new Player();
            player.Name = addPlayerViewModel.Name;
            player.RoleId = Role.Player;
            await _playerRepository.Add(player);
        }

        public async Task AddPlayer(RequestAddPlayerView addPlayerView)
        {
            Player player = new Player();
            player.Name = addPlayerView.Name;
            player.RoleId = Role.Player;
            await _playerRepository.Add(player);
        }

        public async Task<IEnumerable<GetDealersView>> GetDealers()
        {
            List<GetDealersView> dealers = new List<GetDealersView>();
            var getDealers = await _playerRepository.GetDealers();
            foreach(Player d in getDealers)
            {
                GetDealersView dealer = new GetDealersView();
                dealer.Id = d.Id;
                dealer.Name = d.Name;
                dealers.Add(dealer);
            }
            return dealers;
        }

        public async Task<IEnumerable<GetPlayersView>> GetPlayers()
        {
            List<GetPlayersView> players = new List<GetPlayersView>();
            var getPlayers = await _playerRepository.GetPlayers();
            foreach (Player p in getPlayers)
            {
                GetPlayersView player = new GetPlayersView();
                player.Id = p.Id;
                player.Name = p.Name;
                players.Add(player);
            }
            return players;
        }

    }
}
