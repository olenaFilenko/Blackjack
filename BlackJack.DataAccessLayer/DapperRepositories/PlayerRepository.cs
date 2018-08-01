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
    public class PlayerRepository : IPlayerRepository
    {
        private IDbConnection db = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\MyDB.mdf'; Integrated Security = True");

        public PlayerRepository() {
            db.Open();
        }

        /*~PlayerRepository()
        {
            db.Close();
        }*/
        public  Task DeletePlayer(int id)
        {
            //db.Open();
            return db.ExecuteAsync("DELETE FROM Players WHERE Id=@Id", new { Id = id });
        }

        public Task<IEnumerable<Player>> GetAllPlayers()
        {
            //db.Open();
            return db.QueryAsync<Player>("SELECT * FROM Players");
        }

        public Task<IEnumerable<Player>> GetBots()
        {
            //db.Open();
            return db.QueryAsync<Player>("SELECT * FROM Players WHERE RoleId=@Role", new { Role = Role.Bot });
        }

        public async Task<IEnumerable<Player>> GetDealers()
        {
            //db.Open();
            IEnumerable < Player > dealers= await db.QueryAsync<Player>("SELECT * FROM Players WHERE RoleId=@Role", new { Role = Role.Dealer });
            
            return dealers;
        }

        public Task<Player> GetPlayerById(int id)
        {
            //db.Open();
            return db.QueryFirstOrDefaultAsync<Player>("Select * From Players WHERE Id=@Id", new { Id = id });
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            //db.Open();
            IEnumerable<Player> players= await db.QueryAsync<Player>("SELECT * FROM Players WHERE RoleId=@Role", new { Role = Role.Player });
            //db.Close();
            return players;
            
        }

        public Task InsertPlayer(Player player)
        {
            string sql = "INSERT INTO Players (Name, Points, RoleId) Values(@Name, @Points, @RoleId);";
            //db.Open();
            return db.ExecuteAsync(sql, new { Name = player.Name, Points = player.Points, RoleId = (int)player.RoleId });
        }

        public Task Save()
        {
            //db.Open();
            return db.ExecuteAsync("COMMIT;");
        }

        public Task UpdatePlayer(Player player)
        {
            string sql = "UPDATE Players SET Name=@Name, Points=@Points, RoleId=@RoleId WHERE Id=@Id;";
            //db.Open();
            return db.ExecuteAsync(sql, new { Name = player.Name, Points = player.Points, RoleId =(int)player.RoleId, Id = player.Id });
        }
    }
}

