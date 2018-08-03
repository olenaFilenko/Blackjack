using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;

namespace BlackJack.DataAccess.DapperRepositories
{
    public class GamePlayerRepository:GenericRepository<GamePlayer>,IGamePlayerRepository
    {
        private string _connectionString;

        public GamePlayerRepository(string connectionString):base(connectionString)
        {
            _connectionString=connectionString;
        }
         
        public async Task<IEnumerable<GamePlayer>> GetGamePlayersByGameId(int id)
        {
            var result = new List<GamePlayer>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                 result= ( await db.QueryAsync<GamePlayer>("SELECT * FROM GamePlayers WHERE GameId=@Id", new { Id = id })).ToList();
            }
            return result;
        }
    }
}
