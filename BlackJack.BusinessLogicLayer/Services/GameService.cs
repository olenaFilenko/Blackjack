using System;
using System.Collections.Generic;
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
        
        private IGenericRepository<Game> _gameRepository;
        private IPlayerRepository _playerRepository;
        private IGamePlayerRepository _gamePlayerRepository;
        private IGenericRepository<Card> _cardRepository;
        
        public GameService(IGenericRepository<Game> gameRepository, IGamePlayerRepository gamePlayerRepository,
            IPlayerRepository playerRepository, IGenericRepository<Card> cardRepository)
        {            
            _gameRepository = gameRepository;
            _gamePlayerRepository = gamePlayerRepository;
            _playerRepository = playerRepository;
            _cardRepository= cardRepository;
        }
        
        public async Task CheckGameRoundResults(int id)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach(GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetById(gp.PlayerId);
                if (player.RoleId != Role.Dealer)
                {
                    if (gp.Points == AppConfig.BlackjackPointNumber && string.IsNullOrEmpty(gp.Result))
                    {
                        gp.Result += "BlackJack ";
                    }
                }
                await _gamePlayerRepository.Update(gp);
            }
        }

        public async Task Enough(int id)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            GamePlayer dealer = new GamePlayer();
            foreach(GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetById(gp.PlayerId);
                if (player.RoleId == Role.Dealer)
                {
                    dealer = gp;
                }
                else
                {
                    gp.Result += "Enough";
                    await _gamePlayerRepository.Update(gp);
                }
            }
            Card card = new Card();
            while (dealer.Points < AppConfig.DealerPointsStopNumber)
            {
                card = await PassCard();
                await StartGameRound(dealer.Id, card);
                dealer= await _gamePlayerRepository.GetById(dealer.Id);
            }
            await CheckGameRoundResults(id);
            await FinishGame(id);
        }

        private async Task FinishGame(int id)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            List<GamePlayer> players = new List<GamePlayer>();
            GamePlayer dealer = new GamePlayer();
            foreach(GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetById(gp.PlayerId);
                if (player.RoleId != Role.Dealer)
                {
                    players.Add(gp);
                }
                else {
                    dealer = gp;
                } 
            }
            foreach(GamePlayer gp in players)
            {
                if (gp.Id == dealer.Id) continue;
                else
                {
                    if (dealer.Points <= AppConfig.BlackjackPointNumber)
                    {
                        if (dealer.Points == AppConfig.BlackjackPointNumber && gp.Points < AppConfig.BlackjackPointNumber) gp.Result += " You lost";
                        else
                        {
                            if (gp.Points > dealer.Points && gp.Points <= AppConfig.BlackjackPointNumber)
                            {
                                gp.Result += " You won";
                            }
                            else
                            {
                                if (gp.Points == dealer.Points && gp.Points <= AppConfig.BlackjackPointNumber) gp.Result += " Even";
                                else gp.Result += " You lost";
                            }
                        }
                    }
                    else
                    {
                        if (gp.Points <= AppConfig.BlackjackPointNumber)
                        {
                            gp.Result += " You won";
                        }
                        else
                        {
                            gp.Result += " You lost";
                        }
                    }
                    
                    await _gamePlayerRepository.Update(gp);
                }                
            }
        }

        private async Task StartFirstGameRound(int id)
        {
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId( id);
            foreach(GamePlayer gp in gamePlayers)
            {
                Card card1 = await PassCard();
                Card card2 = await PassCard();
                await StartGameRound(gp.Id, card1);
                await StartGameRound(gp.Id, card2);
            }
            await CheckGameRoundResults(id);
        }
        
        private async Task StartGameRound(int gamePlayerId, Card passCard)
        { 
            GamePlayer gamePlayer = await _gamePlayerRepository.GetById(gamePlayerId );
            if (string.IsNullOrEmpty(gamePlayer.Result))
            {
                if (gamePlayer.Points <= AppConfig.BlackjackPointNumber)
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
            await _gamePlayerRepository.Update(gamePlayer);
            
        }

        private async Task<Card> PassCard()
        {
            var cards = await _cardRepository.All();
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

        public async Task More(int id)
        {
            List<GamePlayer> listGamePlayers = new List<GamePlayer>();
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach (GamePlayer gp in gamePlayers)
            {
                Player player = await _playerRepository.GetById(gp.PlayerId);
                if (player.RoleId != Role.Dealer)
                {
                    GamePlayer gamePlayer = new GamePlayer();
                    gamePlayer.Id = gp.Id;
                    gamePlayer.PlayerId = player.Id;
                    gamePlayer.GameId = gp.GameId;
                    gamePlayer.Points = gp.Points;
                    gamePlayer.Result = gp.Result;
                    listGamePlayers.Add(gamePlayer);
                }
            }
            foreach (GamePlayer gp in listGamePlayers)
            {
                Card card = await PassCard();
                await StartGameRound(gp.Id, card);
            }
            await CheckGameRoundResults(id);
        }

        public async Task<StartGameView> Start()
        {
            StartGameView game = new StartGameView();
            var players = await _playerRepository.GetPlayers();
            var dealers = await _playerRepository.GetDealers();
            game.Dealers = new List<PlayerStartGameViewItem>();
            game.Players = new List<PlayerStartGameViewItem>();
            foreach(Player player in players)
            {
                PlayerStartGameViewItem playerStartGame = new PlayerStartGameViewItem();
                playerStartGame.Id = player.Id;
                playerStartGame.Name = player.Name;
                game.Players.Add(playerStartGame);
            }
            foreach(Player dealer in dealers)
            {
                PlayerStartGameViewItem dealerStartGame = new PlayerStartGameViewItem();
                dealerStartGame.Id = dealer.Id;
                dealerStartGame.Name = dealer.Name;
                game.Dealers.Add(dealerStartGame);
            }
            return game;

        }

        public async Task<int> Start(StartGameView startGameView)
        {
            Game game = new Game();
            if (startGameView.Name == null) startGameView.Name = "Game Default name";
            game.Name = startGameView.Name;
            int gameId = await _gameRepository.Add(game);
            GamePlayer dealer = new GamePlayer();
            dealer.GameId = gameId;
            dealer.PlayerId = startGameView.DealerId;
            dealer.Points = 0;
            dealer.Result = string.Empty;
            await _gamePlayerRepository.Add(dealer);
            if (startGameView.PlayerId == 0)
            {
                Player newPlayer = new Player();
                newPlayer.Name = startGameView.NewPlayerName;
                newPlayer.RoleId = Role.Player;
                startGameView.PlayerId = await _playerRepository.Add(newPlayer);
            }
            GamePlayer player = new GamePlayer();
            player.GameId = gameId;
            player.PlayerId = startGameView.PlayerId;
            player.Points = 0;
            player.Result = string.Empty;
            await _gamePlayerRepository.Add(player);
            var bots = await _playerRepository.GetBots();
            int botsNumberCounter = 0;
            foreach(Player bot in bots)
            {
                if (botsNumberCounter >= startGameView.BotsNumber)
                {
                    break;
                }
                else
                {
                    GamePlayer gameBot = new GamePlayer();
                    gameBot.GameId = gameId;
                    gameBot.PlayerId = bot.Id;
                    gameBot.Points = 0;
                    gameBot.Result = string.Empty;
                    await _gamePlayerRepository.Add(gameBot);
                    botsNumberCounter++;
                }
            }
            await StartFirstGameRound(gameId);
            return gameId;
        }

        public async Task<PlayGameView> Play(int id)
        {
            PlayGameView playGameView = new PlayGameView();
            playGameView.Id = id;
            Game game= await _gameRepository.GetById(id);
            playGameView.Name = game.Name;
            playGameView.CreationDate = game.CreationDate;
            playGameView.Players = new List<GamePlayerPlayGameViewItem>();
            var allGamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            foreach(GamePlayer gp in allGamePlayers)
            {
                GamePlayerPlayGameViewItem gpView = new GamePlayerPlayGameViewItem();
                Player player = await _playerRepository.GetById(gp.PlayerId);
                gpView.Id = gp.Id;
                gpView.Name = player.Name;
                gpView.PlayerId = player.Id;
                gpView.GameId = id;
                gpView.Points = gp.Points;
                gpView.Result = gp.Result;
                if (player.RoleId == Role.Dealer)
                {
                    playGameView.Dealer = gpView;
                }
                else
                {
                    playGameView.Players.Add(gpView);
                }
            }
            return playGameView;

        }

        public async Task<HistoryGameView> History()
        {
            HistoryGameView history = new HistoryGameView();
            history.Games = new List<HistoryGameViewItem>();           
            var games = await _gameRepository.All();
            foreach(Game game in games)
            {
                HistoryGameViewItem historyGame = new HistoryGameViewItem();
                historyGame.Id = game.Id;
                historyGame.Name = game.Name;
                historyGame.CreationDate = game.CreationDate;
                var players = await _gamePlayerRepository.GetGamePlayersByGameId( game.Id);
                foreach(GamePlayer gp in players)
                {
                    Player player = await _playerRepository.GetById(gp.PlayerId);
                    if (player.RoleId == Role.Dealer)
                    {
                        historyGame.DealerName = player.Name;
                    }
                    else
                    {
                        if (player.RoleId == Role.Player)
                        {
                            historyGame.PlayerName = player.Name;
                        }
                        else continue;
                    }
                }
                history.Games.Add(historyGame);
            }
            return history;
        }

        public async Task<DetailsGameView> Details(int id)
        {
            DetailsGameView detailsGameView = new DetailsGameView();
            Game game = await _gameRepository.GetById(id );
            detailsGameView.Id = game.Id;
            detailsGameView.Name = game.Name;
            detailsGameView.CreationDate = game.CreationDate;
            var gamePlayers = await _gamePlayerRepository.GetGamePlayersByGameId(id);
            detailsGameView.Players = new List<GamePlayerDetailsGameViewItem>();
            foreach(GamePlayer gp in gamePlayers)
            {
                GamePlayerDetailsGameViewItem gamePlayerViewItem = new GamePlayerDetailsGameViewItem();
                Player player = await _playerRepository.GetById( gp.PlayerId);
                gamePlayerViewItem.Id = gp.Id;
                gamePlayerViewItem.PlayerId = gp.PlayerId;
                gamePlayerViewItem.Name = player.Name;
                gamePlayerViewItem.Points = gp.Points;
                gamePlayerViewItem.Result = gp.Result;
                if (player.RoleId == Role.Dealer)
                {
                    detailsGameView.Dealer = gamePlayerViewItem;
                }
                else
                {
                    detailsGameView.Players.Add(gamePlayerViewItem);
                }

            }
            return detailsGameView;
        }
    }
}
