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

namespace BlackJack.DataAccess.DapperRepositories
{
    public class GamePlayerRepository:IGamePlayerRepository
    {
        private IDbConnection db = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\MyDB.mdf'; Integrated Security = True");

        public GamePlayerRepository()
        {
            db.Open();
        }

        /*~GamePlayerRepository()
        {
            db.Close();
        }*/

        public Task DeleteGamePlayer(int id)
        {
            //db.Open();
            return db.ExecuteAsync("DELETE FROM GamePlayers WHERE Id=@Id", new { Id = id });
        }

        public Task<GamePlayer> GetGameDealerByGameId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GamePlayer> GetGamePlayerById(int id)
        {
            //db.Open();
            return db.QueryFirstOrDefaultAsync<GamePlayer>("Select * From GamePlayers WHERE Id=@Id", new { Id = id }); 
        }

        public Task<IEnumerable<GamePlayer>> GetGamePlayers()
        {
            //db.Open();
            return db.QueryAsync<GamePlayer>("SELECT * FROM GamePlayers");
        }

        public Task<IEnumerable<GamePlayer>> GetGamePlayersByGameId(int id)
        {
            //db.Open();
            return db.QueryAsync<GamePlayer>("SELECT * FROM GamePlayers WHERE GameId=@Id", new { Id=id});
        }

        public Task<IEnumerable<GamePlayer>> GetGamePlayersWithoutDealerByGameId(int id)
        {
            //db.Open();
            return db.QueryAsync<GamePlayer>("SELECT gp.Id, gp.GameId, gp.PlayerId, gp.Result FROM GamePlayers gp, Players p WHERE gp.GameId=@Id AND p.RoleId!=@RoleId ;", new { Id = id, RoleId=Role.Dealer});
        }

        public Task InsertGamePlayer(GamePlayer player)
        {
            string sql = "INSERT INTO GamePlayers (GameId, PlayerId, Result) Values(@GameId, @PlayerId, @Result);";
            //db.Open();
            return db.ExecuteAsync(sql, new { GameId=player.GameId, PlayerId=player.PlayerId, Result=player.Result });
        }

        public Task Save()
        {
            //db.Open();
            return db.ExecuteAsync("COMMIT;");
        }

        public Task UpdateGamePlayer(GamePlayer player)
        {
            string sql = "UPDATE GamePlayers SET GameId=@GameId, PlayerId=@PlayerId, Result=@Result WHERE Id=@Id;";
            //db.Open();
            return db.ExecuteAsync(sql, new { Id = player.Id, GameId = player.GameId, PlayerId = player.PlayerId, Result = player.Result });
        }
    }
}
