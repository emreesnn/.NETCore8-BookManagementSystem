using bms.Application.Interfaces;
using bms.Domain.Entities;
using bms.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bms.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext dbContext;
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<bool> CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id, bool permanent = false)
        {
            var entity = await Table.FindAsync(id);

            if (entity == null) { return false; }

            await Task.Run(() => Table.Remove(entity));
            await dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            await Task.Run(() => Table.Update(entity));
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();
            return await queryable.ToListAsync();
        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            queryable.Where(predicate);
            return await queryable.FirstOrDefaultAsync(predicate);
        }

    }
}
