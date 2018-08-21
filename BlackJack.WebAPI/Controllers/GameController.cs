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
using Newtonsoft.Json.Serialization;
using NLog;

namespace BlackJack.WebAPI.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IGameService _gameService;

       // public GameController() { }

        public GameController(IGameService gameService)
        {
            _gameService= gameService;
        }

        [Route("details/{id:int}")]
        public async Task<IHttpActionResult> GetGameDetails(int id)
        {
            try
            {
                DetailsGameView game = await _gameService.Details(id);
                return Ok(game);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        [Route("getstart")]
        public async Task<IHttpActionResult> GetStart()
        {
            try
            {
                StartGameView startGameView = new StartGameView();
                startGameView = await _gameService.Start();
                return Ok(startGameView);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        [Route("postgame")]
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

        [Route("getplay/{id:int}")]
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
                return NotFound();
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        [Route("enough/{id:int}")]
        public async Task<IHttpActionResult> PutEnough(int id)
        {
            try
            {
                await _gameService.Enough(id);
                return Ok();
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        [Route("enough/{id:int}")]
        public async Task<IHttpActionResult> GetEnough(int id)
        {
            try
            {
                await _gameService.Enough(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        [Route("more/{id:int}")]
        public async Task<IHttpActionResult> PutMore(int id)
        {
            try
            {
                await _gameService.More(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }

        [Route("getgameshistory")]
        public async Task<IHttpActionResult> GetGamesHistory()
        {
            try
            {
                HistoryGameView history = await _gameService.History();
                return Ok(history);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }
    }
}
