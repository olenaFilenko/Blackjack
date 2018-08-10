using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.DataAccess.Interfaces;
using Dapper.Contrib.Extensions;

namespace BlackJack.DataAccess.DapperRepositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private string _connectionString;

        public GenericRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Add(TEntity entity)
        {
            int id = -1;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                id = await db.InsertAsync<TEntity>(entity);
            }
            return id;
        }

        public async Task Add(List<TEntity> entities)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               var ids = await db.InsertAsync(entities);
            }
        }

        public async Task<IEnumerable<TEntity>> All()
        {
            var result = new List<TEntity>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                result = (await db.GetAllAsync<TEntity>()).ToList();
            }
            return result;
        }

        public async Task Delete(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.DeleteAsync<TEntity>(entity);
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            TEntity entity;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                entity = await db.GetAsync<TEntity>(id);
            }
            return entity;
        }
        
        public async Task Update(TEntity entity)
        {
            using(IDbConnection db=new SqlConnection(_connectionString))
            {
                await db.UpdateAsync<TEntity>(entity);
            }
        }

        public async Task Update(List<TEntity> entities)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.UpdateAsync(entities);
            }
        }
    }
}
