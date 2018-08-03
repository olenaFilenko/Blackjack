using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels.PlayerServiceViewModels;

namespace BlackJackFilenko.Controllers
{
    public class PlayerController : AsyncController
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService) {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult> Add() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddPlayerView player)
        {
            try
            {
                await _playerService.AddPlayer(player);
                return RedirectToAction("Start","Game");
            }
            catch(Exception e)
            {
                return View("Error");
            }
            
        }
    }
}