using System.Linq;

namespace SE.Catalog.Contracts
{
    using SE.Catalog.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression);

        void Add(T entity);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();

        Task SaveAsync();

        T FirstOrDefault(Expression<Func<T, bool>> expression);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

        IQueryable<T> Search(PageNSort Criteria);
        IQueryable<T> Search(PageNSort PageParam, Expression<Func<T, bool>> expression);
    }
}
