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
        public static void Configure(ContainerBuilder builder, string connectionString) {
            builder.RegisterType<CardRepository>().As<ICardRepository>().WithParameter("connectionString", connectionString);
            builder.RegisterType<GameRepository>().As<IGameRepository>().WithParameter("connectionString", connectionString);
            builder.RegisterType<GamePlayerRepository>().As<IGamePlayerRepository>().WithParameter("connectionString", connectionString);
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>().WithParameter("connectionString", connectionString);
        }
    }
}
