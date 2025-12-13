using DAL.Contexts;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.Repositories
{
    public class GenericRepositoriy<T> : IGenericRepository<T> where T : class
    {
        private readonly StoreDbContext _dbContext;

        public GenericRepositoriy(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        
        public void Delete(T item)
        {
           _dbContext.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        => await _dbContext.Set<T>().FindAsync(id);


        public async Task UpdateAsync(T item)
        {
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> AddAsync(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
    }
}
