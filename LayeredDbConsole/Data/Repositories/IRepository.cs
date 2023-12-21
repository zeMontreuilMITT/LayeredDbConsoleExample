using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredDbConsole.Data.Repositories
{
    public interface IRepository<T, KeyType> where T : IBaseEntity
    {
        public void Create(T entity);
        public void Delete (T entity);
        public T Get (KeyType id);
        public ICollection<T> GetAll();
        public ICollection<T> GetByCondition(Func<T, bool> predicate);
        public void SaveChanges();
    }

    public interface IBaseEntity { }
}
