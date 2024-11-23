using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZACx.Templates.WebApiProject.DataAccess.Contexts;
using ZACx.Templates.WebApiProject.DataAccess.Repositories.Abstract.EntityFramework;

namespace ZACx.Templates.WebApiProject.DataAccess.Repositories.Concrete.EntityFramework
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly ProjectDbContext _dbContext;
        public GenericRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await GetAsync(filter, null, includes);
        }

        public virtual async Task<IEnumerable<TEntity>> GetWithPaginationAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int page = 1, int limit = 10, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip((page - 1) * limit)//page * limit göre belirli bir dizi kaydı atlar.
                         .Take(limit);//Yalnızca limit boyutuna göre belirlenen gerekli miktarda veriyi alır.

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(expression).SingleOrDefaultAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
