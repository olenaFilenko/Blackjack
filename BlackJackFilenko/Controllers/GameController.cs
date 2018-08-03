using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels.GameServiceViewModels;


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
        public async Task<ActionResult> Start()
        {
            
            try
            {
                StartGameView game = await _gameService.Start();
                return View(game);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Start(StartGameView startGame)
        {
            try
            {
                int gameId = await _gameService.Start(startGame);
                return RedirectToAction("Play", new { id = gameId });
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
                PlayGameView game = await _gameService.Play(id);
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
                return RedirectToAction("Play", new { id = gameId });
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
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> History()
        {
            try
            {
                var games = await _gameService.History();
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
                DetailsGameView game = await _gameService.Details(id);
                return View(game);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
    }
}