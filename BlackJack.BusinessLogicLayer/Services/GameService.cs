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
        private ICardRepository _cardRepository;
        private Random _rnd;
        
        public GameService(IGameRepository gameRepository, IGamePlayerRepository gamePlayerRepository, IPlayerRepository playerRepository, ICardRepository cardRepository) {            
            _gameRepository = gameRepository;
            _gamePlayerRepository = gamePlayerRepository;
            _playerRepository = playerRepository;
            _cardRepository= cardRepository;
            _rnd = new Random();
        }
        
        public async Task CheckGameRoundResults(int id)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach(GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetPlayerById(gp.PlayerId);
                if (player.RoleId != Role.Dealer)
                {
                    if (gp.Points == 21 && string.IsNullOrEmpty(gp.Result)) gp.Result += "BlackJack";
                }
                await _gamePlayerRepository.UpdateGamePlayer(gp);
            }
        }

        public async Task Delete(int id)
        {
            await _gameRepository.DeleteGame(id);
        }

        public async Task Enough(int id)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            GamePlayer dealer = new GamePlayer();
            foreach(GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetPlayerById(gp.PlayerId);
                if (player.RoleId == Role.Dealer)
                {
                    dealer = gp;
                }
                else
                {
                    gp.Result += "Enough";
                    await _gamePlayerRepository.UpdateGamePlayer(gp);
                }
            }
            Card card = new Card();
            while (dealer.Points < 17)
            {
                card = await PassCard();
                await StartGameRound(dealer.Id, card);
                dealer= await _gamePlayerRepository.GetGamePlayerById(dealer.Id);
            }
        }

        public async Task FinishGame(ShowGameViewModel showGame)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(showGame.Id);
            GamePlayer dealer =( from gp in gamePlayers where gp.PlayerId == showGame.DealerId select gp).FirstOrDefault();
            foreach(GamePlayer gp in gamePlayers)
            {
                if (gp.Id == dealer.Id) continue;
                else
                {
                    if (dealer.Points <= 21)
                    {
                        if (dealer.Points == 21 && gp.Points < 21) gp.Result += " You lost";
                        else
                        {
                            if (gp.Points > dealer.Points && gp.Points <= 21) gp.Result += " You won";
                            else
                            {
                                if (gp.Points == dealer.Points && gp.Points <= 21) gp.Result += " Even";
                                else gp.Result += " You lost";
                            }
                        }
                    }
                    else
                    {
                        if (gp.Points <= 21) gp.Result += " You won";
                        else gp.Result += " You lost";
                    }
                    
                    await _gamePlayerRepository.UpdateGamePlayer(gp);
                }                
            }
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

        public async Task Save()
        {
            await _gameRepository.Save();
            await _gamePlayerRepository.Save();
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

        public async Task StartFirstGameRound(int id)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach(GamePlayer gp in gamePlayers)
            {
                Card card1 = await PassCard();
                Card card2 = await PassCard();
                await StartGameRound(gp.Id, card1);
                await StartGameRound(gp.Id, card2);
            }
            await CheckGameRoundResults(id);
        }

        public async Task<int> StartGame(StartGameViewModel startGame)
        {
            Game game = new Game();
            game.Name = startGame.Name;            
            int gameId= await _gameRepository.InsertGame(game);
            GamePlayer gamePlayer = new GamePlayer();
            GamePlayer gameDealer = new GamePlayer();
            gamePlayer.PlayerId = startGame.PlayerId;
            gamePlayer.GameId = gameId;
            gamePlayer.Points = 0;
            gamePlayer.Result = string.Empty;
            gameDealer.PlayerId = startGame.DealerId;
            gameDealer.GameId = gameId;
            gameDealer.Points = 0;
            gameDealer.Result = string.Empty;
            await _gamePlayerRepository.InsertGamePlayer(gamePlayer);
            await _gamePlayerRepository.InsertGamePlayer(gameDealer);
            var bots = await _playerRepository.GetBots();
            int botNumberCounter = 0;
            foreach (Player bot in bots)
            {
                if (botNumberCounter >= startGame.BotsNumber) break;
                GamePlayer gameBot = new GamePlayer();
                gameBot.PlayerId = bot.Id;
                gameBot.GameId = gameId;
                gameBot.Points = 0;
                gameBot.Result = string.Empty;
                await _gamePlayerRepository.InsertGamePlayer(gameBot);
                botNumberCounter++;
            }
            return gameId;
        }

        public async Task StartGameRound(int gamePlayerId, Card passCard)
        { 
            GamePlayer gamePlayer = await _gamePlayerRepository.GetGamePlayerById(gamePlayerId);
            if (string.IsNullOrEmpty(gamePlayer.Result))
            {
                if (gamePlayer.Points <= 21)
                {
                    gamePlayer.Points += passCard.Value;
                }
                else
                {
                    if (passCard.Value == 11)
                    {
                        gamePlayer.Points += 1;
                    }
                    else
                    {
                        gamePlayer.Points += passCard.Value;
                    }
                }
            }
            await _gamePlayerRepository.UpdateGamePlayer(gamePlayer);
            
        }

        public async Task<Card> PassCard()
        {
            var cards = await _cardRepository.GetCards();
            int cardNumber = cards.Count<Card>();
            Card[] cardDeck = new Card[cardNumber];
            int i = 0;
            foreach (Card c in cards)
            {
                cardDeck[i] = c;
                i++;
            }
            int cardRandomIndex = _rnd.Next(0, (cardNumber - 1));
            Card card = cardDeck[cardRandomIndex];
            return card;
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
                showGamePlayer.Points = gp.Points;
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
                    showGamePlayer.Points = gp.Points;
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
                    dealer.Points = gp.Points;
                    dealer.Result = gp.Result;
                }
            }
            return dealer;
        }

        public async Task More(int id)
        {
            List<GamePlayer> showGamePlayers = new List<GamePlayer>();
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach (GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetPlayerById(gp.PlayerId);
                if (player.RoleId != Role.Dealer)
                {
                    GamePlayer gamePlayer = new GamePlayer();
                    gamePlayer.Id = gp.Id;
                    gamePlayer.PlayerId = player.Id;
                    gamePlayer.GameId = gp.GameId;
                    gamePlayer.Points = gp.Points;
                    gamePlayer.Result = gp.Result;
                    showGamePlayers.Add(gamePlayer);
                }
            }
            foreach (GamePlayer gp in showGamePlayers)
            {
                Card card = await PassCard();
                await StartGameRound(gp.Id, card);
            }
        }
    }
}
