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

        public GameController(IGameService gameService) {
            _gameService = gameService;
            
        }

        // GET: Game
        [HttpGet]
        public async Task<ActionResult> StartGame()
        {
            try
            {
                var dealers = await _gameService.GetAllDealers();
                var players = await _gameService.GetAllPlayers();
                ViewBag.Dealers = new SelectList(dealers, "Id", "Name");
                ViewBag.Players = new SelectList(players, "Id", "Name");
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> StartGame(StartGameViewModel startGame)
        {
            try
            {
                int gameId = await _gameService.StartGame(startGame);
                await _gameService.StartFirstGameRound(gameId);
                return RedirectToAction("Play", new { id = gameId });
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }
        
        [HttpGet]
        public async Task<ActionResult> Play(int id)
        {
            try
            {
                var gamePlayers = await _gameService.GetAllGamePlayersWithoutDealerByGameId(id);
                ShowGamePlayerViewModel dealer = await _gameService.GetGameDealerByGameId(id);
                ShowGameViewModel game = await _gameService.ShowGame(id);
                ViewBag.Dealer = dealer;
                ViewBag.Players = gamePlayers;
                return View(game);
            }
            catch(Exception e)
            {
                return View("Error");
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Enough(int gameId)
        {
            try
            {  
                await _gameService.Enough(gameId);
                ShowGameViewModel game = await _gameService.ShowGame(gameId);
                await _gameService.FinishGame(game);
                return RedirectToAction("Play", new { id =  gameId});
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
                await _gameService.More(gameId);
                return RedirectToAction("Play", new { id = gameId });
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
                ShowGamePlayerViewModel dealer = await _gameService.GetGameDealerByGameId(id);
                ViewBag.Dealer = dealer;
                var players = await _gameService.GetAllGamePlayersWithoutDealerByGameId(id);
                ViewBag.Players = players;
                return View(game);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
    }
}