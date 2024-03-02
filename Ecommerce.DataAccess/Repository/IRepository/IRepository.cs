using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Crud
        public IEnumerable<T> GetAll();
        public T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);

    }
}
