using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using BlackJack.ViewModels.PlayerServiceViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IPlayerService
    {
        Task AddPlayer(AddPlayerViewModel addPlayerViewModel );
        Task AddDealer(AddPlayerViewModel addPlayerViewModel);
        Task AddBot(AddPlayerViewModel addPlayerViewModel);
        Task UpdatePlayer(UpdatePlayerViewModel updatePlayerViewModel);
        Task<UpdatePlayerViewModel> Update(int id);
        Task RemovePlayer(int id);
        Task<GetPlayerByIdViewModel> GetPlayerById(int id);
        Task<IEnumerable<GetAllPlayersViewModel>> GetAllPlayers();
        Task<IEnumerable<GetAllDealersViewModel>> GetAllDealers();
        Task<IEnumerable<GetAllBotsViewModel>> GetAllBots();
        Task Save();


    }
}
