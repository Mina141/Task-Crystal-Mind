using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_CrystalMind.Models.Repositories
{
    public interface IGenericRepostory<T>
    {
        IList<T> List();
        T Read (int id);
        T Create (T entity);
        void Update (T entity);
        void Delete(int id);
    }
}
