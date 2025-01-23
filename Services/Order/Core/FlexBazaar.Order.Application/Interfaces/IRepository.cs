using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task <List<T>> GetAllAsync();
        Task<T> GetByIdAysnc(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T Entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
