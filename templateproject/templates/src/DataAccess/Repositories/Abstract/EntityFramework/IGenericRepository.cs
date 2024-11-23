using System.Linq.Expressions;

namespace ZACx.Templates.WebApiProject.DataAccess.Repositories.Abstract.EntityFramework
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetWithPaginationAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int page = 1, int limit = 10, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
    }
}
