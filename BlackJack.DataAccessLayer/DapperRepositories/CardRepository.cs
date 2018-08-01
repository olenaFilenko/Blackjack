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
    public class CardRepository : ICardRepository
    {
        private IDbConnection db = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\MyDB.mdf'; Integrated Security = True");

        public CardRepository()
        {
            db.Open();
        }
        /*~CardRepository()
        {
            db.Close();
        }*/

        public Task DeleteCard(int id)
        {
            //db.Open();
            return db.ExecuteAsync("DELETE FROM Cards WHERE Id=@Id", new { Id = id });
        }

        public Task<Card> GetCardById(int id)
        {
            //db.Open();
            return db.QueryFirstOrDefaultAsync<Card>("Select * From Cards WHERE Id=@Id", new { Id = id });
        }

        public Task<IEnumerable<Card>> GetCards()
        {
            //db.Open();
            return db.QueryAsync<Card>("SELECT * FROM Cards");
        }

        public Task InsertCard(Card card)
        {
            string sql = "INSERT INTO Cards ( Name, Value) Values(@Name, @Value);";
            //db.Open();
            return db.ExecuteAsync(sql, new { Name =card.Name, Value=card.Value});
        }

        public Task Save()
        {
            //db.Open();
            return db.ExecuteAsync("COMMIT;");
        }

        public Task UpdateCard(Card card)
        {
            string sql = "UPDATE Cards SET Name=@Name, Value=@Value WHERE Id=@Id;";
            //db.Open();
            return db.ExecuteAsync(sql, new { Name = card.Name, Value = card.Value, Id = card.Id });
        }
    }
}
