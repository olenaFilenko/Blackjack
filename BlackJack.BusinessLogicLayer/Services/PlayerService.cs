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

        public async Task<GetDealersView> GetDealers()
        {
            GetDealersView dealers = new GetDealersView();
            dealers.Dealers = new List<GetDealersViewItem>();
            var getDealers = await _playerRepository.GetDealers();
            foreach(Player d in getDealers)
            {
                GetDealersViewItem dealer = new GetDealersViewItem();
                dealer.Id = d.Id;
                dealer.Name = d.Name;
                dealers.Dealers.Add(dealer);
            }
            return dealers;
        }

        public async Task<GetPlayersView> GetPlayers()
        {
            GetPlayersView players = new GetPlayersView();
            players.Players = new List<GetPlayersViewItem>();
            var getPlayers = await _playerRepository.GetPlayers();
            foreach (Player p in getPlayers)
            {
                GetPlayersViewItem player = new GetPlayersViewItem();
                player.Id = p.Id;
                player.Name = p.Name;
                players.Players.Add(player);
            }
            return players;
        }

    }
}
