using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class ShowGameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DealerId { get; set; }
        public int PlayerId { get; set; }
        public int BotsNumber { get; set; }
        
    }
}
