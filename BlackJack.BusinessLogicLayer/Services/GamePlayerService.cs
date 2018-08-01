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
using BlackJack.ViewModels.GamePlayerServiceViewModels;
using BlackJack.DataAccess.DapperRepositories;

namespace BlackJack.BusinessLogic.Services
{
    public class GamePlayerService : IGamePlayerService
    {
        //private BlackJackContext _context;
        private IGamePlayerRepository _gamePlayerRepository;
        private IPlayerRepository _playerRepository;

        public GamePlayerService( IGamePlayerRepository gamePlayerRepository, IPlayerRepository playerRepository) {
            //_context = new BlackJackContext();
            _gamePlayerRepository = gamePlayerRepository;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<ShowGamePlayerViewModel>> GetAllGamePlayersByGameId(int id)
        {
            List<ShowGamePlayerViewModel> showGamePlayers = new List<ShowGamePlayerViewModel>();
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach (GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetPlayerById(gp.PlayerId);                 
                ShowGamePlayerViewModel showGamePlayer = new ShowGamePlayerViewModel();
                showGamePlayer.Id = gp.Id;
                showGamePlayer.PlayerId = player.Id;
                showGamePlayer.GameId = gp.GameId;
                showGamePlayer.Name = player.Name;
                showGamePlayer.Points = player.Points;
                showGamePlayer.Result = gp.Result;
                showGamePlayers.Add(showGamePlayer);               
            }
            return showGamePlayers;

        }

        public async Task<IEnumerable<ShowGamePlayerViewModel>> GetAllGamePlayersWithoutDealerByGameId(int id)
        {
            List<ShowGamePlayerViewModel> showGamePlayers = new List<ShowGamePlayerViewModel>();
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach (GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetPlayerById(gp.PlayerId);
                if (player.RoleId != Role.Dealer)
                {
                    ShowGamePlayerViewModel showGamePlayer = new ShowGamePlayerViewModel();
                    showGamePlayer.Id = gp.Id;
                    showGamePlayer.PlayerId = player.Id;
                    showGamePlayer.GameId = gp.GameId;
                    showGamePlayer.Name = player.Name;
                    showGamePlayer.Points = player.Points;
                    showGamePlayer.Result = gp.Result;
                    showGamePlayers.Add(showGamePlayer);
                }
            }
            return showGamePlayers;
        }

        public async Task<ShowGamePlayerViewModel> GetGameDealerByGameId(int id)
        {

            ShowGamePlayerViewModel dealer = new ShowGamePlayerViewModel();
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach (GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetPlayerById(gp.PlayerId);
                if (player.RoleId == Role.Dealer)
                {
                    dealer.Id = gp.Id;
                    dealer.PlayerId = player.Id;
                    dealer.GameId = gp.GameId;
                    dealer.Name = player.Name;
                    dealer.Points = player.Points;
                    dealer.Result = gp.Result;
                    
                }
            }
            return dealer;
        }

        public async Task<ShowGamePlayerViewModel> ShowGamePlayer(int id)
        {
            ShowGamePlayerViewModel showGamePlayer = new ShowGamePlayerViewModel();
            GamePlayer gamePlayer = await _gamePlayerRepository.GetGamePlayerById(id);
            showGamePlayer.Id = gamePlayer.Id;
            Player player = await _playerRepository.GetPlayerById(gamePlayer.PlayerId);
            showGamePlayer.PlayerId = player.Id;
            showGamePlayer.GameId = gamePlayer.GameId;
            showGamePlayer.Name = player.Name;
            showGamePlayer.Points = player.Points;
            showGamePlayer.Result = gamePlayer.Result;
            return showGamePlayer;
        }
    }
}
