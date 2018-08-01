using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using BlackJack.ViewModels.PlayerServiceViewModels;

namespace BlackJackFilenko.Controllers
{
    public class PlayerController : AsyncController
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService) {
            _playerService = playerService;
        }

        // GET: Player
        public async Task<ActionResult> Index()
        {
            try
            {
                var players = await _playerService.GetAllPlayers();
                return View(players);
            }
            catch (Exception e) {
                return View("Error");
            }
            
        }

        [HttpGet]
        public async Task<ActionResult> Add() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddPlayerViewModel player)
        {
            try
            {
                await _playerService.AddPlayer(player);
                return RedirectToAction("StartGame","Game");
                return View();
            }
            catch(Exception e)
            {
                return View("Error");
            }
            
        }

        [HttpGet]
        public async Task<ActionResult> Show(int id)
        {
            try
            {
                GetPlayerByIdViewModel player = await _playerService.GetPlayerById(id);
                return View(player);
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id) {
            try
            {
                UpdatePlayerViewModel updatePlayer = await _playerService.Update(id);
                return View(updatePlayer);
            }
            catch(Exception e)
            {
                return View("Error");
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdatePlayerViewModel player)
        {
            try
            {
                await _playerService.UpdatePlayer(player);
                return RedirectToAction("Index");
                return View();
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                GetPlayerByIdViewModel player = await _playerService.GetPlayerById(id);
                return View(player);
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _playerService.RemovePlayer(id);
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