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
    public class GameRepository : IGameRepository
    {
        private IDbConnection db = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\MyDB.mdf'; Integrated Security = True");

        public GameRepository()
        {
            db.Open();
        }

        /*~GameRepository()
        {
            db.Close();
        }*/

        public Task DeleteGame(int id)
        {
            //db.Open();
            return db.ExecuteAsync("DELETE FROM Games WHERE Id=@Id", new { Id = id });
        }

        public Task<Game> GetGameById(int id)
        {
            //db.Open();
            return db.QueryFirstOrDefaultAsync<Game>("Select * From Games WHERE Id=@Id", new { Id = id }); ;
        }

        public Task<IEnumerable<Game>> GetGames()
        {
            //db.Open();
            return db.QueryAsync<Game>("SELECT * FROM Games");
        }

        public Task InsertGame(Game game)
        {
            string sql = "INSERT INTO Games (Name, SetParametrsStatus) Values(@Name, @SetParametrsStatus);";
            //db.Open();
            return db.ExecuteAsync(sql, new { Name=game.Name , SetParametrsStatus =game.SetParametrsStatus});
        }

        public Task Save()
        {
            //db.Open();
            return db.ExecuteAsync("COMMIT;");
        }

        public Task UpdateGame(Game game)
        {
            string sql = "UPDATE Games SET Name=@Name, SetParametrsStatus=@SetParametrsStatus WHERE Id=@Id;";
            //db.Open();
            return db.ExecuteAsync(sql, new {Id = game.Id , Name=game.Name , SetParametrsStatus =game.SetParametrsStatus});
        }
    }
}
