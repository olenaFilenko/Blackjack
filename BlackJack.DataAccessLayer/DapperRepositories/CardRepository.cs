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
    public class CardRepository : ICardRepository
    {
        private string _connectionString;
        
        public CardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public async Task DeleteCard(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync("DELETE FROM Cards WHERE Id=@Id", new { Id = id });
            } 
        }

        public async Task<Card> GetCardById(int id)
        {
            Card card = new Card();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               card= await db.QueryFirstOrDefaultAsync<Card>("Select * From Cards WHERE Id=@Id", new { Id = id });
            }
            return card;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            var cards = new List<Card>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                cards=(await db.QueryAsync<Card>("SELECT * FROM Cards")).ToList();
            }
            return cards;
        }

        public async Task InsertCard(Card card)
        {
            //string sql = "INSERT INTO Cards ( Name, Value) Values(@Name, @Value);";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                //await db.QueryAsync(sql, new {Name=card.Name, Value=card.Value });
                await db.InsertAsync(card);
            }                
        }

        public async Task Save()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync("COMMIT;");
            }                
        }

        public async Task UpdateCard(Card card)
        {
           // string sql = "UPDATE Cards SET Name=@Name, Value=@Value WHERE Id=@Id;";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.UpdateAsync(card);
            }                
        }
    }
}
