using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdAsync(string id);

        Task<IEnumerable<TEntity>> GetWithPagination(int quantity, int page, Expression<Func<TEntity, bool>> expresion = null);

        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> expresion);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expresion = null);

        Task<bool> InsertAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<bool> DeleteAsync(int id);

        Task<bool> DeleteAsync(string id);

    }
}
