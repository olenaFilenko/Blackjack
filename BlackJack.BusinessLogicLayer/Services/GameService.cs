using System;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.GameServiceViewModels;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {   
        private static Random _rnd = new Random();
        
        private IGameRepository _gameRepository;
        private IPlayerRepository _playerRepository;
        private IGamePlayerRepository _gamePlayerRepository;
        private ICardRepository _cardRepository;
        private Card[] _cards;
        
        public GameService(IGameRepository gameRepository, IGamePlayerRepository gamePlayerRepository,
            IPlayerRepository playerRepository, ICardRepository cardRepository)
        {            
            _gameRepository = gameRepository;
            _gamePlayerRepository = gamePlayerRepository;
            _playerRepository = playerRepository;
            _cardRepository= cardRepository;
        }
        
        public async Task CheckGameRoundResults(int id)
        {
            var gamePlayers = (await _gamePlayerRepository.GetGamePlayersWithoutDealerByGameId(id)).ToList();
            foreach(var gp in gamePlayers)
            {
                if (gp.Points == AppConfig.BlackjackPointNumber && gp.Result!=GameResult.Blackjack)
                {
                    gp.Result=GameResult.Blackjack;
                }
            }
            await _gamePlayerRepository.Update(gamePlayers);
        }

        public async Task Enough(int id)
        {
            var gamePlayers = (await _gamePlayerRepository.GetGamePlayersWithoutDealerByGameId(id)).ToList();
            var dealer = await _gamePlayerRepository.GetGameDealerByGameId(id);
            var card = new Card();
            while (dealer.Points < AppConfig.DealerPointsStopNumber)
            {
                card = await PassCard();
                StartGameRound(dealer, card);
            }
            await _gamePlayerRepository.Update(dealer);
            await CheckGameRoundResults(id);
            await FinishGame(id);
        }

        private async Task FinishGame(int id)
        {
            var players = (await _gamePlayerRepository.GetGamePlayersWithoutDealerByGameId(id)).ToList();
            var dealer = await _gamePlayerRepository.GetGameDealerByGameId(id);
            foreach (var gp in players)
            {
                if (gp.Points <= AppConfig.BlackjackPointNumber && (gp.Points > dealer.Points || dealer.Points > AppConfig.BlackjackPointNumber))
                {
                    gp.Result = GameResult.Won;
                    continue;
                }
                if (gp.Points <= AppConfig.BlackjackPointNumber && gp.Points == dealer.Points)
                {
                    gp.Result = GameResult.Even;
                    continue;
                }
                gp.Result = GameResult.Lost;
            }
            await _gamePlayerRepository.Update(players);
        }

        private async Task StartFirstGameRound(int id)
        {
            var gamePlayers =( await _gamePlayerRepository.GetGamePlayersByGameId(id)).ToList();
            foreach(var gp in gamePlayers)
            {
                var card1 = await PassCard();
                var card2 = await PassCard();
                StartGameRound(gp, card1);
                StartGameRound(gp, card2);
            }
            await _gamePlayerRepository.Update(gamePlayers);
            await CheckGameRoundResults(id);
        }
        
        private void StartGameRound(GamePlayer gamePlayer, Card passCard)
        {
            bool valueChaged = false;
            if((gamePlayer.Points > AppConfig.AceChangeValueNumber && passCard.Value == 11) && (!valueChaged))
            {
                gamePlayer.Points += 1;
                valueChaged = true;
            }
            if(!valueChaged)
            {
                gamePlayer.Points += passCard.Value;
            }
            
        }

        private async Task<Card> PassCard()
        {
            if (_cards == null)
            {
                _cards= (await _cardRepository.All()).ToArray();
            }
            int cardRandomIndex = _rnd.Next(0, (_cards.Length - 1));
            var card = _cards[cardRandomIndex];
            return card;
        }

        public async Task More(int id)
        {
            var listGamePlayers =( await _gamePlayerRepository.GetGamePlayersWithoutDealerByGameId(id)).ToList();
            var gamePlayers = (from l in listGamePlayers where l.Result == GameResult.More && l.Points<=AppConfig.BlackjackPointNumber select l).ToList();
            foreach (var gp in gamePlayers)
            {
                var card = await PassCard();
                StartGameRound(gp, card);
            }
            await _gamePlayerRepository.Update(gamePlayers);
            await CheckGameRoundResults(id);
        }

        public async Task<StartGameView> Start()
        {
            StartGameView game = new StartGameView();
            var players = await _playerRepository.GetPlayers();
            var dealers = await _playerRepository.GetDealers();
            game.Dealers = dealers.Select(x => new PlayerStartGameViewItem()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            game.Players = players.Select(x => new PlayerStartGameViewItem()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return game;
        }

        public async Task<int> Start(StartGameView startGameView)
        {
            Game game = new Game();
            if (startGameView.Name == null)
            {
                startGameView.Name = "Game Default name";
            }
            game.Name = startGameView.Name;
            int gameId = await _gameRepository.Add(game);
            GamePlayer dealer = new GamePlayer();
            dealer.GameId = gameId;
            dealer.PlayerId = (int)startGameView.DealerId;
            dealer.Points = 0;
            dealer.Result = GameResult.More;
            await _gamePlayerRepository.Add(dealer);
            if (startGameView.PlayerId == 0)
            {
                var newPlayer = new Player();
                newPlayer.Name = startGameView.NewPlayerName;
                newPlayer.RoleId = Role.Player;
                startGameView.PlayerId = await _playerRepository.Add(newPlayer);
            }
            GamePlayer player = new GamePlayer();
            player.GameId = gameId;
            player.PlayerId =(int) startGameView.PlayerId;
            player.Points = 0;
            player.Result = GameResult.More;
            await _gamePlayerRepository.Add(player);
            var bots = await _playerRepository.GetBots();
            var gameBots =bots.Select(x => new GamePlayer()
            {
                GameId = gameId,
                PlayerId = x.Id,
                Points = 0,
                Result = GameResult.More
            }).Take(startGameView.BotsNumber).ToList();
            await _gamePlayerRepository.Add(gameBots);
            await StartFirstGameRound(gameId);
            return gameId;
        }

        public async Task<PlayGameView> Play(int id)
        {
            PlayGameView playGameView = new PlayGameView();
            playGameView.Id = id;
            var game= await _gameRepository.GetById(id);
            playGameView.Name = game.Name;
            playGameView.CreationDate = game.CreationDate;
            var allGamePlayers = await _gamePlayerRepository.GetGamePlayersByGameIdIncludePlayerEntity(id);
            playGameView.Players = allGamePlayers.Where(a => (!a.Player.RoleId.Equals(Role.Dealer)))
                .Select(a => new GamePlayerPlayGameViewItem()
            {
                Id=a.Id,
                Name=a.Player.Name,
                PlayerId=a.PlayerId,
                GameId=id,
                Points=a.Points,
                Result=a.Result.ToString()

            }).ToList();
            playGameView.Dealer = allGamePlayers.Where(a => (a.Player.RoleId.Equals(Role.Dealer)))
                .Select(a => new GamePlayerPlayGameViewItem()
            {
                Id = a.Id,
                Name = a.Player.Name,
                PlayerId = a.PlayerId,
                GameId = id,
                Points = a.Points,
                Result = a.Result.ToString()

            }).FirstOrDefault();
            return playGameView;

        }

        public async Task<HistoryGameView> History()
        {
            HistoryGameView history = new HistoryGameView();
            var games = await _gameRepository.All();
            foreach(var game in games)
            {
                HistoryGameViewItem historyGame = new HistoryGameViewItem();
                historyGame.Id = game.Id;
                historyGame.Name = game.Name;
                historyGame.CreationDate = game.CreationDate;
                var gamePlayer = await _gamePlayerRepository.GetGamePlayerByGameIdIncludePlayerEntity(game.Id);
                if (gamePlayer != null)
                {
                    historyGame.PlayerName = gamePlayer.Player.Name;
                }
                var gameDealer = await _gamePlayerRepository.GetGameDealerByGameIdIncludePlayerEntity(game.Id);
                if (gameDealer != null)
                {
                    historyGame.DealerName = gameDealer.Player.Name;
                }
                history.Games.Add(historyGame);
            }
            return history;
        }

        public async Task<DetailsGameView> Details(int id)
        {
            DetailsGameView detailsGameView = new DetailsGameView();
            var game = await _gameRepository.GetById(id );
            detailsGameView.Id = game.Id;
            detailsGameView.Name = game.Name;
            detailsGameView.CreationDate = game.CreationDate;
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameIdIncludePlayerEntity(id);
            detailsGameView.Dealer = gamePlayers.Where(gp => (gp.Player.RoleId.Equals(Role.Dealer)))
                .Select(gp => new GamePlayerDetailsGameViewItem() {
                    Id=gp.Id,
                    Name=gp.Player.Name,
                    GameId=id,
                    PlayerId=gp.PlayerId,
                    Points=gp.Points,
                    Result=gp.Result.ToString()
                }).FirstOrDefault();
            detailsGameView.Players= gamePlayers.Where(gp => (!gp.Player.RoleId.Equals(Role.Dealer)))
                .Select(gp => new GamePlayerDetailsGameViewItem()
                {
                    Id = gp.Id,
                    Name = gp.Player.Name,
                    GameId = id,
                    PlayerId = gp.PlayerId,
                    Points = gp.Points,
                    Result = gp.Result.ToString()
                }).ToList();
            return detailsGameView;
        }
    }
}
