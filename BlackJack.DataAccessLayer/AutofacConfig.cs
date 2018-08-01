using Autofac;
using BlackJack.DataAccess.DapperRepositories;
using BlackJack.DataAccess.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack.DataAccess
{
    public static class AutofacConfig
    {
        public static void Configure(ContainerBuilder builder) {
            builder.RegisterType<CardRepository>().As<ICardRepository>();
            builder.RegisterType<GameRepository>().As<IGameRepository>();
            builder.RegisterType<GamePlayerRepository>().As<IGamePlayerRepository>();
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>();
        }
    }
}
