using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.GamePlayerServiceViewModels;


namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGamePlayerService
    {
        Task<ShowGamePlayerViewModel> ShowGamePlayer(int id);
        Task<IEnumerable<ShowGamePlayerViewModel>> GetAllGamePlayersByGameId(int id);
        Task<IEnumerable<ShowGamePlayerViewModel>> GetAllGamePlayersWithoutDealerByGameId(int id);       
        Task<ShowGamePlayerViewModel> GetGameDealerByGameId(int id); 
    }
}
