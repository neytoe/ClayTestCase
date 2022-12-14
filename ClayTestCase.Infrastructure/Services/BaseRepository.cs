using ClayTestCase.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Infrastructure.Services
{
  
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly AssessmentDataContext _dataContext;
        private readonly DbSet<T> entitySet;
        public BaseRepository(AssessmentDataContext dataContext)
        {
            _dataContext = dataContext;
            entitySet = dataContext.Set<T>();
        }
        public async Task Delete(int? id)
        {
            if (await Exist(id))
            {
                var entity = await Find(id);
                _dataContext.Remove(entity);
                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task<bool> Exist(int? id)
        {
            var entity = await entitySet.FindAsync(id);
            return entity != null ? true : false;
        }
        public virtual async Task<T> Find(int? id)
        {
            var entity = await entitySet.FindAsync(id);
            return entity;
        }
        public virtual async Task<IEnumerable<T>> FindAll()
        {
            return await entitySet.ToListAsync();
        }
        public async Task<int> Count()
        {
            return await entitySet.CountAsync();
        }
        public async Task Save(T t)
        {
            if (t != null)
            {
                entitySet.Add(t);
                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task Update(T t)
        {
            if (t != null)
            {
                _dataContext.Update(t);
                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task AddRange(T[] t)
        {
            _dataContext.AddRange(t);
            await _dataContext.SaveChangesAsync();
        }
    }
    
}
