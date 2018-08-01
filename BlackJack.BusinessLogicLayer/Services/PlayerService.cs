using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Iterfaces;
//using BlackJack.DataAccess.EntityFrameworkRepository;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.PlayerServiceViewModels;
using BlackJack.DataAccess.DapperRepositories;

namespace BlackJack.BusinessLogic.Services
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _playerRepository;        

        public PlayerService(IPlayerRepository playerRepository) {           
            _playerRepository = playerRepository;
        }

        public async Task AddBot(AddPlayerViewModel addPlayerViewModel)
        {
            Player player = new Player();
            player.Name = addPlayerViewModel.Name;            
            player.RoleId = Role.Bot;
            await _playerRepository.InsertPlayer(player);
        }

        public async Task AddDealer(AddPlayerViewModel addPlayerViewModel)
        {
            Player player = new Player();
            player.Name = addPlayerViewModel.Name;           
            player.RoleId = Role.Dealer;
            await _playerRepository.InsertPlayer(player);
        }

        public async Task AddPlayer(AddPlayerViewModel addPlayerViewModel)
        {
            Player player = new Player();
            player.Name = addPlayerViewModel.Name;
            player.RoleId = Role.Player;
            await _playerRepository.InsertPlayer(player);

        }

        public async Task<IEnumerable<GetAllBotsViewModel>> GetAllBots()
        {
            List<GetAllBotsViewModel> allBots = new List<GetAllBotsViewModel>();
            var players = await _playerRepository.GetAllPlayers();
            foreach (Player pl in players)
            {
                if (pl.RoleId.Equals(Role.Bot))
                {
                    GetAllBotsViewModel allBotsItem = new GetAllBotsViewModel();
                    allBotsItem.Id = pl.Id;
                    allBotsItem.Name = pl.Name;
                    allBots.Add(allBotsItem);
                }
            }
            return allBots;
        }

        public async Task<IEnumerable<GetAllDealersViewModel>> GetAllDealers()
        {
            List<GetAllDealersViewModel> allDealers = new List<GetAllDealersViewModel>();
            var players = await _playerRepository.GetAllPlayers();
            foreach (Player pl in players)
            {
                if (pl.RoleId.Equals(Role.Dealer))
                {
                    GetAllDealersViewModel allDealerItem = new GetAllDealersViewModel();
                    allDealerItem.Id = pl.Id;
                    allDealerItem.Name = pl.Name;
                    allDealers.Add(allDealerItem);
                }
            }
            return allDealers;
        }

        public async Task<IEnumerable<GetAllPlayersViewModel>> GetAllPlayers()
        {
            List<GetAllPlayersViewModel> allPlayers = new List<GetAllPlayersViewModel>();
            var players = await _playerRepository.GetPlayers();
            foreach (Player pl in players)
            {
                if (pl.RoleId.Equals(Role.Player))
                {
                    GetAllPlayersViewModel allPlayer = new GetAllPlayersViewModel();
                    allPlayer.Id = pl.Id;
                    allPlayer.Name = pl.Name;
                    allPlayers.Add(allPlayer);
                }
            }
            return allPlayers;
        }

        public async Task<GetPlayerByIdViewModel> GetPlayerById(int id)
        {
            GetPlayerByIdViewModel player = new GetPlayerByIdViewModel();
            Player pl = await _playerRepository.GetPlayerById(id);
            player.Id = pl.Id;
            player.Name = pl.Name;
            return player;
        }

        public async Task RemovePlayer(int id)
        {
            await _playerRepository.DeletePlayer(id);
        }

        public async Task Save()
        {
            await _playerRepository.Save();
        }

        public async Task<UpdatePlayerViewModel> Update(int id)
        {
            UpdatePlayerViewModel updatePlayer = new UpdatePlayerViewModel();
            Player player = await _playerRepository.GetPlayerById(id);
            updatePlayer.Id = player.Id;
            updatePlayer.Name = player.Name;
            return updatePlayer;
        }

        public async Task UpdatePlayer(UpdatePlayerViewModel updatePlayerViewModel)
        {
            Player player = await _playerRepository.GetPlayerById(updatePlayerViewModel.Id);
            player.Id = updatePlayerViewModel.Id;
            player.Name = updatePlayerViewModel.Name;
            //player.RoleId = Role.Player;
            await _playerRepository.UpdatePlayer(player);
        }
    }
}
