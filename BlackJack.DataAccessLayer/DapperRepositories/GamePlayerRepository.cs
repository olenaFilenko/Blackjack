using System.Collections.Generic;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities.Enums;
using BlackJack.Entities.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using Dapper.Mapper;

namespace BlackJack.DataAccess.DapperRepositories
{
    public class GamePlayerRepository:GenericRepository<GamePlayer>,IGamePlayerRepository
    {
        private string _connectionString;
        private string sqlQueryGetGamePlayersWithoutDealerByGameId = "SELECT GamePlayers.Id, GamePlayers.GameId, GamePlayers.PlayerId, GamePlayers.Result, GamePlayers.Points, GamePlayers.CreationDate FROM GamePlayers LEFT JOIN Players ON GamePlayers.PlayerId=Players.Id WHERE GamePlayers.GameId=@GameId AND Players.RoleId!=@RoleId;";
        private string sqlQueryGetGamePlayerByGameId= "SELECT GamePlayers.Id, GamePlayers.GameId, GamePlayers.PlayerId, GamePlayers.Result, GamePlayers.Points, GamePlayers.CreationDate FROM GamePlayers LEFT JOIN Players ON GamePlayers.PlayerId=Players.Id WHERE GamePlayers.GameId=@GameId AND Players.RoleId=@RoleId;";
        private string sqlQueryGetGamePlayersIncludePlayerEntity = "SELECT * FROM GamePlayers AS A INNER JOIN Players AS B ON A.PlayerId=B.Id;";
        private string sqlQueryGetGamePlayersByGameIdIncludePlayerEntity = "SELECT * FROM GamePlayers AS A INNER JOIN Players AS B ON A.PlayerId=B.Id WHERE A.GameId=@GameId;";
        private string sqlQueryGetGamePlayerByGameIdIncludePlayerEntity = "SELECT * FROM GamePlayers AS A INNER JOIN Players AS B ON A.PlayerId=B.Id WHERE A.GameId=@GameId AND B.RoleId=@RoleId;";
         

        public GamePlayerRepository(string connectionString):base(connectionString)
        {
            _connectionString=connectionString;
        }

        public async Task<GamePlayer> GetGameDealerByGameId(int id)
        {
            GamePlayer gamePlayer;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                gamePlayer = await db.QueryFirstOrDefaultAsync<GamePlayer>(sqlQueryGetGamePlayerByGameId, new { GameId = id, RoleId = Role.Dealer });
            }
            return gamePlayer;
        }

        public async Task<GamePlayer> GetGameDealerByGameIdIncludePlayerEntity(int id)
        {
            var result = new GamePlayer();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                result = (await db.QueryAsync<GamePlayer, Player>(sqlQueryGetGamePlayerByGameIdIncludePlayerEntity, new { GameId = id, RoleId = Role.Dealer })).FirstOrDefault();
            }
            return result;

        }

        public async Task<GamePlayer> GetGamePlayerByGameId(int id)
        {
            GamePlayer gamePlayer;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                gamePlayer = await db.QueryFirstOrDefaultAsync<GamePlayer>(sqlQueryGetGamePlayerByGameId, new { GameId = id, RoleId = Role.Player});
            }
            return gamePlayer;
        }

        public async Task<GamePlayer> GetGamePlayerByGameIdIncludePlayerEntity(int id)
        {
            var result = new GamePlayer();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                result = (await db.QueryAsync<GamePlayer,Player>(sqlQueryGetGamePlayerByGameIdIncludePlayerEntity, new { GameId = id, RoleId = Role.Player })).FirstOrDefault();
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

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersByGameIdIncludePlayerEntity(int id)
        {
            var gamePlayers = new List<GamePlayer>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                gamePlayers = (await db.QueryAsync<GamePlayer, Player>(sqlQueryGetGamePlayersByGameIdIncludePlayerEntity, new {GameId=id })).ToList();
            }
            return gamePlayers;
        }

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersIncludePlayerEntity()
        {
            var gamePlayers = new List<GamePlayer>();
            using (IDbConnection db = new SqlConnection(_connectionString)) {
                gamePlayers = (await db.QueryAsync<GamePlayer, Player>(sqlQueryGetGamePlayersIncludePlayerEntity)).ToList();
            }
            return gamePlayers;
        }

        public async Task<IEnumerable<GamePlayer>> GetGamePlayersWithoutDealerByGameId(int id)
        {
            var result = new List<GamePlayer>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                result = (await db.QueryAsync<GamePlayer>(sqlQueryGetGamePlayersWithoutDealerByGameId, new { GameId = id, RoleId=Role.Dealer})).ToList();
            }
            return result;
        }
    }
}
