using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.DataAccess.Iterfaces;
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
    public class GamePlayerRepository:IGamePlayerRepository
    {
        private string _connectionString;

        public GamePlayerRepository(string connectionString)
        {
            _connectionString=connectionString;
        }
                
        public async Task DeleteGamePlayer(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync("DELETE FROM GamePlayers WHERE Id=@Id", new { Id = id });
            }
        }

        public Task<GamePlayer> GetGameDealerByGameId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GamePlayer> GetGamePlayerById(int id)
        {
            GamePlayer gamePlayer = new GamePlayer();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                gamePlayer= await db.QueryFirstOrDefaultAsync<GamePlayer>("Select * From GamePlayers WHERE Id=@Id", new { Id = id });
            }
            return gamePlayer;
        }

        public async Task<IEnumerable<GamePlayer>> GetGamePlayers()
        {
            var result = new List<GamePlayer>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                 result=( await db.QueryAsync<GamePlayer>("SELECT * FROM GamePlayers")).ToList();
            }
            return result;
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

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersWithoutDealerByGameId(int id)
        {
            var result = new List<GamePlayer>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
              result=(await db.QueryAsync<GamePlayer>("SELECT gp.Id, gp.GameId, gp.PlayerId, gp.Result FROM GamePlayers gp, Players p WHERE gp.GameId=@Id AND p.RoleId!=@RoleId ;", new { Id = id, RoleId = Role.Dealer })).ToList();
            }
            return result;
        }

        public async Task InsertGamePlayer(GamePlayer player)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.InsertAsync<GamePlayer>(player);
            }
        }

        public async Task Save()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync("COMMIT;");
            }
        }

        public async Task UpdateGamePlayer(GamePlayer player)
        {          
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.UpdateAsync(player);
            }
        }
    }
}
