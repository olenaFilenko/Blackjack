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
using BlackJack.ViewModels.GameServiceViewModels;
using BlackJack.ViewModels.CardServiceViewModel;
using BlackJack.ViewModels.GamePlayerServiceViewModels;
using BlackJack.ViewModels.PlayerServiceViewModels;
using BlackJack.DataAccess.DapperRepositories;
using BalackJack.Entities.Enums;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {        
        private IGameRepository _gameRepository;
        private IGamePlayerRepository _gamePlayerRepository;
        private IPlayerRepository _playerRepository;
        //private BlackJackContext _context;

        public GameService(IGameRepository gameRepository, IGamePlayerRepository gamePlayerRepository, IPlayerRepository playerRepository) {
            //_context = new BlackJackContext();
            _gameRepository = gameRepository;
            _gamePlayerRepository = gamePlayerRepository;
            _playerRepository = playerRepository;
        }
                
        public async Task CalculateGameResult(ShowGamePlayerViewModel player, GetPlayerByIdViewModel dealer)
        {

            if (player.Points > dealer.Points && player.Points<=21) player.Result = "You won";
            else
            {
                if (player.Points == dealer.Points) player.Result = "Even";
                else player.Result = "You lost";
            }
            GamePlayer gamePlayer = await _gamePlayerRepository.GetGamePlayerById(player.Id);
            gamePlayer.Result = player.Result;
            await _gamePlayerRepository.UpdateGamePlayer(gamePlayer);
        }

        public async Task CheckGameRoundResults(ShowGamePlayerViewModel showGamePlayer)
        {            
            GamePlayer gamePlayer = await _gamePlayerRepository.GetGamePlayerById(showGamePlayer.Id);
            Player player = await _playerRepository.GetPlayerById(showGamePlayer.PlayerId);
            if (player.RoleId != Role.Dealer)
            {
                if (player.Points == 21 && string.IsNullOrEmpty(gamePlayer.Result)) gamePlayer.Result = "BlackJack";
            }            
            await _gamePlayerRepository.UpdateGamePlayer(gamePlayer);
        }

        public async Task Delete(int id)
        {
            await _gameRepository.DeleteGame(id);
        }

        public async Task Enough(int id)
        {

            GamePlayer gamePlayer = await _gamePlayerRepository.GetGamePlayerById(id);
            gamePlayer.Result = "Enough";
            await _gamePlayerRepository.UpdateGamePlayer(gamePlayer);
        }

        public async Task FinishFirstGameRound(ShowGameViewModel showGame)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersWithoutDealerByGameId(showGame.Id);
            Player dealer = await _playerRepository.GetPlayerById(showGame.DealerId);
            foreach(GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetPlayerById(gp.PlayerId);
                if (dealer.Points == 21 && player.Points < 21) gp.Result = "You lost";
                await _gamePlayerRepository.UpdateGamePlayer(gp);
            }
            
        }

        public async Task FinishGame(ShowGamePlayerViewModel player)
        {
            Player pl = await _playerRepository.GetPlayerById(player.PlayerId);
            pl.Points = 0;
            await _playerRepository.UpdatePlayer(pl);
        }

        public async Task<IEnumerable<GetAllGamesViewModel>> GetAllGames()
        {
            List<GetAllGamesViewModel> allGames = new List<GetAllGamesViewModel>();
            var games = await _gameRepository.GetGames();
            foreach (Game g in games)
            {
                GetAllGamesViewModel allGamesItem = new GetAllGamesViewModel();
                var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(g.Id);
                allGamesItem.Id = g.Id;
                allGamesItem.Name = g.Name;
                allGamesItem.BotsNumber = 0;
                allGamesItem.SetParametrsStatus = g.SetParametrsStatus;
                foreach (GamePlayer gp in gamePlayers)
                {
                    Player p = await _playerRepository.GetPlayerById(gp.PlayerId);
                    if (p.RoleId.Equals(Role.Player))
                    {
                        allGamesItem.Player = p.Name;
                    }
                    else
                    {
                        if (p.RoleId.Equals(Role.Dealer))
                        {
                            allGamesItem.Dealer = p.Name;
                        }
                        else allGamesItem.BotsNumber += 1;
                    }

                }
                allGames.Add(allGamesItem);
            }
            return allGames;

        }
                
        public async Task Save()
        {
            await _gameRepository.Save();
            await _gamePlayerRepository.Save();
        }

        public async Task SetGame(SetGameViewModel setGame)
        {
            GamePlayer gamePlayer = new GamePlayer();
            GamePlayer gameDealer = new GamePlayer();            
            gamePlayer.PlayerId = setGame.PlayerId;
            gamePlayer.GameId = setGame.Id;
            gamePlayer.Result = string.Empty;
            gameDealer.PlayerId = setGame.DealerId;
            gameDealer.GameId = setGame.Id;
            gameDealer.Result = string.Empty;            
            await _gamePlayerRepository.InsertGamePlayer(gamePlayer);
            await _gamePlayerRepository.InsertGamePlayer(gameDealer);
            var bots = await _playerRepository.GetBots();
            int botNumberCounter = 0;
            foreach (Player bot in bots)
            {
                if (botNumberCounter >= setGame.BotsNumber) break;
                GamePlayer gameBot = new GamePlayer();
                gameBot.PlayerId = bot.Id;
                gameBot.GameId = setGame.Id;
                gameBot.Result = string.Empty;
                await _gamePlayerRepository.InsertGamePlayer(gameBot);
                botNumberCounter++;
            }
            Game game = await _gameRepository.GetGameById(setGame.Id);
            game.SetParametrsStatus = (int)SetParametersStatus.Set;
            await _gameRepository.UpdateGame(game);
        }

        public async Task<SetGameViewModel> SetGame(int id)
        {
            Game game = await _gameRepository.GetGameById(id);
            SetGameViewModel setGame = new SetGameViewModel();
            setGame.Id = game.Id;
            setGame.Name = game.Name;
            return setGame;
        }

        public async Task<ShowGameViewModel> ShowGame(int id)
        {
            ShowGameViewModel showGame = new ShowGameViewModel();
            Game game = await _gameRepository.GetGameById(id);
            showGame.Id = game.Id;
            showGame.Name = game.Name;
            GetAllGamesViewModel allGamesItem = new GetAllGamesViewModel();
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);

            foreach (GamePlayer gp in gamePlayers)
            {
                Player p = await _playerRepository.GetPlayerById(gp.PlayerId);
                if (p.RoleId.Equals(Role.Player))
                {
                    showGame.PlayerId = p.Id;
                }
                else
                {
                    if (p.RoleId.Equals(Role.Dealer))
                    {
                        showGame.DealerId = p.Id;
                    }
                    else showGame.BotsNumber += 1;
                }
            }
            
            return showGame;
        }

        public async Task StartGame(StartGameViewModel startGame)
        {
            Game game = new Game();
            game.Name = startGame.Name;
            game.SetParametrsStatus =(int)SetParametersStatus.Unset;
            await _gameRepository.InsertGame(game);            
        }

        public async Task StartGameRound(int gamePlayerId, PassCardViewModel passCard, int playerId)
        {           
            Player player = await _playerRepository.GetPlayerById(playerId);
            GamePlayer gamePlayer = await _gamePlayerRepository.GetGamePlayerById(gamePlayerId);
            if (string.IsNullOrEmpty(gamePlayer.Result))
            {
                if (player.Points <= 21)
                {
                    player.Points += passCard.Value;
                }
                else
                {
                    if (passCard.Value == 11)
                    {
                        player.Points += 1;
                    }
                    else
                    {
                        player.Points += passCard.Value;
                    }
                }
            }
            await _playerRepository.UpdatePlayer(player);
            
        }

    }
}
