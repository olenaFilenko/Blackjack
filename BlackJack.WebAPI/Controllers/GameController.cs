using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels.GameServiceViewModels;
using NLog;

namespace BlackJack.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GameController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IGameService _gameService;

        public GameController(IGameService gameService) {
            _gameService= gameService;
        }

        public async Task<IHttpActionResult> GetStart()
        {
            try
            {
                StartGameView startGameView = new StartGameView();
                startGameView = await _gameService.Start();
                return Ok(startGameView);
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        public async Task<IHttpActionResult> PostGame([FromBody]StartGameView startGameView)
        {
            try
            {
                int gameId = await _gameService.Start(startGameView);
                return Ok(gameId);
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        public async Task<IHttpActionResult> GetPlay(int id)
        {
            try
            {
                PlayGameView playGameView = new PlayGameView();
                playGameView = await _gameService.Play(id);
                if (playGameView != null)
                {
                    return Ok(playGameView);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        public async Task<IHttpActionResult> PutPlayerAction(int id, bool isMoreRequred)
        {
            try
            {
                if (isMoreRequred)
                {
                    await _gameService.More(id);
                }
                else
                {
                    await _gameService.Enough(id);
                }
                return Ok();
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IHttpActionResult> GetGamesHistory()
        {
            try
            {
                return Ok(await _gameService.History());
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }
    }
}
