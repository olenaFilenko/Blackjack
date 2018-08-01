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
    public class PlayerRepository : IPlayerRepository
    {
        private string _connectionString;

        public PlayerRepository(string connectionString) {
            _connectionString=connectionString;
        }
        
        public async  Task DeletePlayer(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync("DELETE FROM Players WHERE Id=@Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var result = new List<Player>();
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                result = (await db.QueryAsync<Player>("SELECT * FROM Players")).ToList();
            }
            return result;
        }

        public async Task<IEnumerable<Player>> GetBots()
        {
            var result = new List<Player>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                result = (await db.QueryAsync<Player>("SELECT * FROM Players WHERE RoleId=@Role", new { Role = Role.Bot })).ToList();
            }
            return result;
        }

        public async Task<IEnumerable<Player>> GetDealers()
        {
            var dealers = new List<Player>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                dealers = (await db.QueryAsync<Player>("SELECT * FROM Players WHERE RoleId=@Role", new { Role = Role.Dealer })).ToList();
                
            }
            return dealers;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            Player player = new Player();
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                 player=( await db.QueryFirstOrDefaultAsync<Player>("Select * From Players WHERE Id=@Id", new { Id = id }));
            }
            return player;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var players = new List<Player>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                players = (await db.QueryAsync<Player>("SELECT * FROM Players WHERE RoleId=@Role", new { Role = Role.Player })).ToList();
            }
            return players;
        }

        public async Task InsertPlayer(Player player)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.InsertAsync(player);
            }               
        }

        public async Task Save()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync("COMMIT;");
            } 
        }

        public async Task UpdatePlayer(Player player)
        {            
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.UpdateAsync(player);
            }
        }
    }
}

