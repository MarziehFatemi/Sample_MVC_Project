using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiexpert.Repository
{
    public interface IGenericRepository <T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetEntity(int id); 

        bool AddEntity (T entity);

        bool UpdateEntity(T entity);

        bool DeleteEntity (T entity);

        bool DeleteEntity(int id);

        void Save(); 

    }
}
