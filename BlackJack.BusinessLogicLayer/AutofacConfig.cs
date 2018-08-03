using Autofac;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;

namespace BlackJack.BusinessLogicLayer
{
    public static class AutofacConfig
    {
        public  static void Configure(ContainerBuilder builder, string connectionString) {
            builder.RegisterType<GameService>().As<IGameService>();           
            builder.RegisterType<PlayerService>().As<IPlayerService>();            
            DataAccess.AutofacConfig.Configure(builder, connectionString);
        }
    }
}
