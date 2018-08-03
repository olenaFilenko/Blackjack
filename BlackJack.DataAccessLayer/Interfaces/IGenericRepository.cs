using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> All();
        Task<TEntity> GetById(int id);
        Task Delete(TEntity entity);
        Task<int> Add(TEntity entity);
        Task Update(TEntity entity);
    }
}
