using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using marketing_api.Data;
using marketing_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query;


namespace marketing_api.Repositories
{
   
    public class BaseRepository<T> : IBaseRepsitories<T> where T : class
    {
        protected readonly Marketingdbcontext _dbContext;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        public BaseRepository(Marketingdbcontext dbContext,ILogger logger)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            _logger = logger;
        }
        public async Task<T> Add(T entity)
        {
            var createdEntity = await _dbSet.AddAsync(entity);
            return createdEntity.Entity;
        }
        public virtual async Task<bool>? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> IncludeAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
        
        public  IIncludableQueryable<T, object> IncludeAsync2(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            IIncludableQueryable<T, object> result = null;
            foreach (var include in includes)
            {
                result = query.Include(include);
            }

            return  result;
        }
        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual  Task SaveChanges()
        {
            
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Upsert(T entity)
        {
            var entry = _dbContext.Entry(entity);
            switch (entry.State)
            {
                case EntityState.Detached:
                    _dbSet.Add(entity);
                    await _dbContext.SaveChangesAsync();
                    return true;
                case EntityState.Modified:
                    await _dbContext.SaveChangesAsync();
                    return true;
                default:
                    return false;
            }
        }
    }
}
