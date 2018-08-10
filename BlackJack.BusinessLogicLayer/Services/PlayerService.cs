using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.PlayerServiceViewModels;
using System.Linq;

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

        public async Task<GetDealersView> GetDealers()
        {
            GetDealersView dealers = new GetDealersView();
            var getDealers = await _playerRepository.GetDealers();
            dealers.Dealers = getDealers.Select(x => new GetDealersViewItem()
            {
                Id = x.Id,
                Name=x.Name
            }).ToList();
            return dealers;
        }

        public async Task<GetPlayersView> GetPlayers()
        {
            GetPlayersView players = new GetPlayersView();
            var getPlayers = await _playerRepository.GetPlayers();
            players.Players = getPlayers.Select(x=> new GetPlayersViewItem() {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return players;
        }

    }
}
