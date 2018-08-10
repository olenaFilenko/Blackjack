using System.Collections.Generic;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;

namespace BlackJack.DataAccess.DapperRepositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        private string _connectionString;

        public PlayerRepository(string connectionString):base(connectionString)
        {
            _connectionString=connectionString;
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

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var players = new List<Player>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                players = (await db.QueryAsync<Player>("SELECT * FROM Players WHERE RoleId=@Role", new { Role = Role.Player })).ToList();
            }
            return players;
        }
    }
}

