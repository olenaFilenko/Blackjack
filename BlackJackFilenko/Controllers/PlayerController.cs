using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels.PlayerServiceViewModels;
using NLog;

namespace BlackJackFilenko.Controllers
{
    public class PlayerController : AsyncController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService) {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult> Add() {
            return View();
        }

      [HttpPost]
        public async Task<ActionResult> Add(AddPlayerView models)
        {
            try
            {
                await _playerService.AddPlayer(models);
                return RedirectToAction("Start","Game");
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return View("Error");
            }
            
        }
        public async Task<JsonResult> GetDealers()
        {
            var dealers = await _playerService.GetDealers();
            return Json(dealers, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetPlayers()
        {
            var players = await _playerService.GetPlayers();
            return Json(players, JsonRequestBehavior.AllowGet);
        }
    }
}