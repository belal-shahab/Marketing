using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace marketing_api.Repositories.Interfaces;

public interface IBaseRepsitories<T>
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Upsert(T entity);
    Task<bool>? Delete(int id);
    Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> IncludeAsync(params Expression<Func<T, object>>[] includes);
    IIncludableQueryable<T, object> IncludeAsync2(params Expression<Func<T, object>>[] includes);
    Task SaveChanges();
}