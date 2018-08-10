using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.DataAccess.EntityFrameworkRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private BlackJackContext _context;

        public GenericRepository(BlackJackContext context)
        {
            _context= context;
        }

        public async Task<int> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);           
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> All()
        {
            var entityItems =await (from e in _context.Set<TEntity>() select e).ToListAsync();
            return entityItems;
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
             await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task Update(TEntity entity)
        {
             _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Update(List<TEntity> entities)
        {
            foreach(TEntity entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public async Task Add(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _context.Set<TEntity>().Add(entity);
            }
            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
