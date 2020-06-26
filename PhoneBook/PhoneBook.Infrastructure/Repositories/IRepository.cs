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
    public interface IRepository<T> where T: class, new()
    {
        PhoneBookDbContext Context { get; }
        DbSet<T> DbSet { get; }
        Task<T> GetFirstAsync(int id);
        IQueryable<T> FindAll();
        IQueryable<T> Find(Expression<Func<T, bool>> keySelector);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(int id);
        Task SaveChangesAsync();
        Task<bool> SaveAsync();
    }
}
