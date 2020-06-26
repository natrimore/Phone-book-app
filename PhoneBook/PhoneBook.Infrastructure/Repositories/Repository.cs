using Microsoft.EntityFrameworkCore;
using PhoneBook.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public PhoneBookDbContext Context { get; private set; }

        public DbSet<T> DbSet { get; set; }
        public Repository(PhoneBookDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<T> GetFirstAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            return Context.SaveChanges() > 0;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindAll()
        {
            return DbSet.AsQueryable().AsNoTracking();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> keySelector)
        {
            return DbSet.AsQueryable().Where(keySelector);   
        }
    }
}
