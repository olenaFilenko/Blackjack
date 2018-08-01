using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.DataAccess.Iterfaces;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Linq;

namespace BlackJack.DataAccess.DapperRepositories
{
    public class GameRepository : IGameRepository
    {        
        private string _connectionString;

        public GameRepository(string connectionString)
        {
           _connectionString= connectionString;
        }              

        public async Task DeleteGame(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync("DELETE FROM Games WHERE Id=@Id", new { Id = id });
            }                
        }

        public async Task<Game> GetGameById(int id)
        {
            Game game = new Game();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                 game= await db.QueryFirstOrDefaultAsync<Game>("Select * From Games WHERE Id=@Id", new { Id = id });
            }
            return game;
        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            var result = new List<Game>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                 result=(await db.QueryAsync<Game>("SELECT * FROM Games")).ToList();
            }
            return result;
        }

        public async Task<int> InsertGame(Game game)
        {
            int result =-1;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                result= await db.InsertAsync<Game>(game);
            }
            return result;
        }

        public async Task Save()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync("COMMIT;");
            }
        }

        public async Task UpdateGame(Game game)
        {           
            using (IDbConnection db = new SqlConnection(_connectionString)) {
               await db.UpdateAsync(game);
            }            
        }
    }
}
