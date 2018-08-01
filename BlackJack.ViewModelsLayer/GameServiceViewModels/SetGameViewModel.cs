using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.GameServiceViewModels
{
    public class SetGameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DealerId { get; set; }
        public int PlayerId { get; set; }
        [Range(0, 5,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int BotsNumber { get; set; }

    }
}
