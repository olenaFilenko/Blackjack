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
    public class BotController : Controller
    {
        private IPlayerService _playerService;

        public BotController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: Bot
        public async Task<ActionResult> Index()
        {
            try
            {
                var players = await _playerService.GetAllBots();
                return View(players);
            }
            catch(Exception e)
            {
                return View("Error");
            }            
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddPlayerViewModel bot)
        {
            try
            {
                await _playerService.AddBot(bot);
                return RedirectToAction("Index");
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpGet]
        public async Task<ActionResult> Show(int id)
        {
            try
            {
                GetPlayerByIdViewModel bot = await _playerService.GetPlayerById(id);
                return View(bot);
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            try
            {
                UpdatePlayerViewModel updatePlayer = await _playerService.Update(id);
                return View(updatePlayer);
            }
            catch (Exception e)
            {
                return View("Error");
            }           
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdatePlayerViewModel bot)
        {            
            try
            {
                await _playerService.UpdatePlayer(bot);
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
                GetPlayerByIdViewModel bot = await _playerService.GetPlayerById(id);
                return View(bot);
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
            catch (Exception e)
            {
                return View("Error");
            }            
        }
    }
}