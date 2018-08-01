using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using BlackJack.ViewModels.GameServiceViewModels;
using BlackJack.ViewModels.GamePlayerServiceViewModels;
using BlackJack.ViewModels.CardServiceViewModel;
using BlackJack.ViewModels.PlayerServiceViewModels;


namespace BlackJackFilenko.Controllers
{
    public class GameController : AsyncController
    {
        private IGameService _gameService;
        private IGamePlayerService _gamePlayerService;
        private IPlayerService _playerService;
        private ICardService _cardService;

        public GameController(IGameService gameService, IGamePlayerService gamePlayerService, IPlayerService playerService,ICardService cardService) {
            _gameService = gameService;
            _gamePlayerService = gamePlayerService;
            _cardService = cardService;
            _playerService = playerService;
        }

        // GET: Game
        [HttpGet]
        public async Task<ActionResult> StartGame()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> SetGame(int id)
        {
            try
            {
                SetGameViewModel setGame = await _gameService.SetGame(id);
                var dealers = await _playerService.GetAllDealers();
                var players = await _playerService.GetAllPlayers();
                ViewBag.Dealers = new SelectList(dealers, "Id", "Name");
                ViewBag.Players = new SelectList(players, "Id", "Name");
                return View(setGame);
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> SetGame(SetGameViewModel setGame)           
        {
            try
            {
                await _gameService.SetGame(setGame);
                return RedirectToAction("Index");
                return View();
            }
            catch(Exception e)
            {
                return View("Error");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> StartGame(StartGameViewModel startGame)
        {            
            try
            {
                await _gameService.StartGame(startGame);
                return RedirectToAction("Index");
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpPost]
        public async Task<ActionResult> StartGameRound(int gameId, int playerId)
        {
            try
            {
                ShowGamePlayerViewModel dealer = await _gamePlayerService.ShowGamePlayer(gameId);
                ViewBag.Dealer = dealer;
                var gamePlayers = await _gamePlayerService.GetAllGamePlayersByGameId(gameId);
                List<PassCardViewModel> firstCards = new List<PassCardViewModel>();
                foreach (ShowGamePlayerViewModel gp in gamePlayers)
                {
                    PassCardViewModel passCard1 = await _cardService.PassCard();
                    firstCards.Add(passCard1);
                    await _gameService.StartGameRound(gameId, passCard1, playerId);
                }
                ViewBag.Cards = firstCards;
                foreach (ShowGamePlayerViewModel gp in gamePlayers)
                {
                    await _gameService.CheckGameRoundResults(gp);
                }
                var gamePlayersAfterRound = await _gamePlayerService.GetAllGamePlayersWithoutDealerByGameId(gameId);
                ViewBag.GamePlayers = gamePlayersAfterRound;

                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpPost]
        public async Task<ActionResult> StartFirstGameRound(int gameId)
        {           
            try
            {
                ShowGameViewModel game = await _gameService.ShowGame(gameId);
                var gamePlayers = await _gamePlayerService.GetAllGamePlayersByGameId(gameId);
                foreach (ShowGamePlayerViewModel gp in gamePlayers)
                {
                    PassCardViewModel passCard1 = await _cardService.PassCard();
                    PassCardViewModel passCard2 = await _cardService.PassCard();
                    await _gameService.StartGameRound(gp.Id, passCard1, gp.PlayerId);
                    await _gameService.StartGameRound(gp.Id, passCard2, gp.PlayerId);
                }
                foreach (ShowGamePlayerViewModel gp in gamePlayers)
                {
                    await _gameService.CheckGameRoundResults(gp);
                }
                GetPlayerByIdViewModel dealer = await _playerService.GetPlayerById(game.DealerId);
                ViewBag.Dealer = dealer;
                var gamePlayersAfterRound = await _gamePlayerService.GetAllGamePlayersWithoutDealerByGameId(gameId);
                ViewBag.GamePlayers = gamePlayersAfterRound;
                return RedirectToAction("Details", new { id = gameId });
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpPost]
        public async Task<ActionResult> FinishRound(int id)
        {
            try
            {
                ShowGameViewModel game = await _gameService.ShowGame(id);
                var gamePlayers = await _gamePlayerService.GetAllGamePlayersByGameId(id);
                ShowGamePlayerViewModel dealer =new ShowGamePlayerViewModel();
                foreach (ShowGamePlayerViewModel gp in gamePlayers)
                {
                    if (gp.PlayerId == game.DealerId)
                    {
                        dealer = gp;
                    }
                }
                while (dealer.Points < 17)
                {
                    PassCardViewModel passCard = await _cardService.PassCard();
                    await _gameService.StartGameRound(dealer.Id, passCard, dealer.PlayerId);
                    dealer = await _gamePlayerService.ShowGamePlayer(dealer.Id);

                }

                await _gameService.FinishFirstGameRound(game);
                return RedirectToAction("Details", new { id = id });
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Enough(int gameId)
        {
            try
            {
                var gamePlayers = await _gamePlayerService.GetAllGamePlayersWithoutDealerByGameId(gameId);
                foreach (ShowGamePlayerViewModel gp in gamePlayers)
                {
                    await _gameService.Enough(gp.Id);
                }
                return RedirectToAction("Details", new { id =  gameId});
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }           
            
        }

        [HttpPost]
        public async Task<ActionResult> More(int gameId)
        {           
            try
            {
                var gamePlayers = await _gamePlayerService.GetAllGamePlayersWithoutDealerByGameId(gameId);
                foreach(ShowGamePlayerViewModel gp in gamePlayers)
                {
                    PassCardViewModel passCard1 = await _cardService.PassCard();
                    await _gameService.StartGameRound(gp.Id, passCard1, gp.PlayerId);
                    await _gameService.CheckGameRoundResults(gp);
                }
                return RedirectToAction("Details", new { id = gameId });
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }
            

        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var games = await _gameService.GetAllGames();
                return View(games);
            }
            catch (Exception e)
            {
                return View("Error");
            }
            
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id) {
            try
            {
                ShowGameViewModel game = await _gameService.ShowGame(id);
                GetPlayerByIdViewModel dealer = await _playerService.GetPlayerById(game.DealerId);
                ViewBag.Dealer = dealer;
                var players = await _gamePlayerService.GetAllGamePlayersWithoutDealerByGameId(id);
                ViewBag.Players = players;
                return View(game);
            }
            catch (Exception e)
            {
                return View("Error");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> CalculateResult(int gameId)
        {
            try
            {
                ShowGameViewModel game = await _gameService.ShowGame(gameId);
                ViewBag.Game = game;
                GetPlayerByIdViewModel dealer = await _playerService.GetPlayerById(game.DealerId);
                var gamePlayers = await _gamePlayerService.GetAllGamePlayersByGameId(gameId);
                foreach (ShowGamePlayerViewModel gp in gamePlayers)
                {
                    await _gameService.CalculateGameResult(gp, dealer);
                }
                return RedirectToAction("Details", new { id = gameId });
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }
            
        }    
        
        [HttpPost]
        public async Task<ActionResult> CloseGame(int id)
        {
            var gamePlayers = await _gamePlayerService.GetAllGamePlayersByGameId(id);
            foreach(ShowGamePlayerViewModel gp in gamePlayers)
            {
                await _gameService.FinishGame(gp);
            }
            return RedirectToAction("Details", new { id = id });
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TerminateGame(int gameId, int playerId)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }
            
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                ShowGameViewModel game = await _gameService.ShowGame(id);
                return View(game);
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int id) {
            try
            {
                await _gameService.Delete(id);
                return RedirectToAction("Index");
                return View();
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

    }
}