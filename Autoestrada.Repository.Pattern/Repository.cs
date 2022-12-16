using Autoestrada.Domain.Entity.Entities;
using Autoestrada.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Repository.Pattern
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {

        private readonly AutoestradaContext _Context;
        private readonly DbSet<TEntity> _entities;

        public Repository(AutoestradaContext Context)
        {
            _Context = Context;
            _entities = _Context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetWithPagination(int quantity, int page, Expression<Func<TEntity, bool>> expresion = null)
        {
            if (expresion is null) { 
                return await _entities.Skip(quantity * page).Take(quantity).ToListAsync(); 
            }
            else
            {
                return await _entities.Where(expresion).Skip(quantity * page).Take(quantity).ToListAsync();
            }

        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> expresion)
        {
            return await _entities.Where(expresion).ToListAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expresion = null)
        {
            return await _entities.AnyAsync(expresion);
        }
        public async Task<bool> InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            int changes = await _Context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
            int changes = await _Context.SaveChangesAsync();

            return changes > 0;
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _Context.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);
            _Context.Remove(entity);
            int changes = await _Context.SaveChangesAsync();

            return changes > 0;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            TEntity entity = await GetByIdAsync(id);
            _Context.Remove(entity);
            int changes = await _Context.SaveChangesAsync();

            return changes > 0;
        }

    }
}
