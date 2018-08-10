using System.Collections.Generic;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities.Models;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using Dapper.Mapper;

namespace BlackJack.DataAccess.DapperRepositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private static string sqlQueryGetAllGamesIncludeGamePlyerEntity = "SELECT * FROM Game AS A INNER JOIN GamePlayers AS B ON A.Id=B.GameId;";
        private string _connectionString;

        public GameRepository(string connectionString):base(connectionString)
        {
           _connectionString= connectionString;
        }

        public async Task<IEnumerable<Game>> GetAllGamesIncludeGamePlyerEntity()
        {
            var games = new List<Game>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                games = (await db.QueryAsync<Game, GamePlayer>(sqlQueryGetAllGamesIncludeGamePlyerEntity)).ToList();
            }
            return games;
        }
    }
}
