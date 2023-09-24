using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetWithId(int id);
        Task<T> Add(T type);
        Task<int> Update(T type);
    }
}
