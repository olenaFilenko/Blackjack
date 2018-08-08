using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels.PlayerServiceViewModels;
using NLog;

namespace BlackJack.WebAPI.Controllers
{
    public class PlayerController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService= playerService;
        }

        public async Task<IHttpActionResult> PostPlayer([FromBody]AddPlayerView addPlayerView)
        {
            try
            {
                await _playerService.AddPlayer(addPlayerView);
                return Ok();
            }
             catch(Exception e)
            {
                logger.Error(e.Message);
                return BadRequest();
            }
        }
    }
}
