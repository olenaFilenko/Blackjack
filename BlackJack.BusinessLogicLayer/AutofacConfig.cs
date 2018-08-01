using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using BlackJack.DataAccess;

namespace BlackJack.BusinessLogicLayer
{
    public static class AutofacConfig
    {
        public  static void Configure(ContainerBuilder builder ) {
            builder.RegisterType<GameService>().As<IGameService>();
            builder.RegisterType<GamePlayerService>().As<IGamePlayerService>();
            builder.RegisterType<PlayerService>().As<IPlayerService>();
            builder.RegisterType<CardService>().As<ICardService>();
            DataAccess.AutofacConfig.Configure(builder);
        }
    }
}
