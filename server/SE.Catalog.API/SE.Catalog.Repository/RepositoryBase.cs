using SE.Catalog.Models;

namespace SE.Catalog.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SE.Catalog.Contracts;

    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CatalogContext RepositoryContext { get; }      

        public RepositoryBase(CatalogContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> GetAll()
        {
            return RepositoryContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await RepositoryContext.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().Where(expression).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression);
        }
        public bool Any(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Any(expression);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().FirstOrDefault(expression);
        }

        public void Add(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public Task AddAsync(T entity)
        {
            return RepositoryContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }
        
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            RepositoryContext.SaveChanges();
        }

        public Task SaveAsync()
        {
            return RepositoryContext.SaveChangesAsync();
        }

        protected void DisableChangeTracking()
        {
            RepositoryContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            RepositoryContext.ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public static IQueryable<T> PageNSort(IQueryable<T> collection, PageNSort PageParam)
        {

            if (PageParam.Sort != null)
            {
                if (PageParam.SortOrder == SortOrder.Asc)
                {
                    collection = collection.OrderBy(x => x.GetType().GetProperty(PageParam.Sort).GetValue(x, null));
                }
                else
                {
                    collection = collection.OrderByDescending(x => x.GetType().GetProperty(PageParam.Sort).GetValue(x, null));
                }
            }

            collection = collection.Skip((PageParam.PageNumber - 1) * PageParam.PageSize).Take(PageParam.PageSize);

            return collection;
        }

        public IQueryable<T> Search(PageNSort PageParam, Expression<Func<T, bool>> expression)
        {
            IQueryable<T> collection;

            if (expression == null)
            {
                collection = RepositoryContext.Set<T>();
            }
            else
            {
                collection = RepositoryContext.Set<T>().Where(expression);
            }

            return PageNSort(collection, PageParam);
        }

        public IQueryable<T> Search(PageNSort PageParam)
        {
            IQueryable<T> collection = RepositoryContext.Set<T>();

            return PageNSort(collection, PageParam);
        }


    }
}