using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using internTask.BLL.Interfaces;
using internTask.DAL.AppContext;

namespace internTask.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext applicationContext;

        public GenericRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<T> Add(T type)
        {
            var result = await applicationContext.AddAsync(type);
            applicationContext.SaveChanges();
            return result.Entity;
        }

        public async Task<T> GetWithId(int id)
        {
            return await applicationContext.Set<T>().FindAsync(id);
        }

        public async Task<int> Update(T type)
        {
            applicationContext.Set<T>().Update(type);
            return await applicationContext.SaveChangesAsync();
        }
    }
}
