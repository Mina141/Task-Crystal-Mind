using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_CrystalMind.Data;
using Task_CrystalMind.Models;
using Task_CrystalMind.Models.Repositories;

namespace Task_CrystalMind.Logic_Layer.Repositories
{
    public class GenericRepostory<T> : IGenericRepostory<T> where T : BaseModel
    {
        private readonly DataContext dataContext;
        DbSet<T> Table;

        public GenericRepostory(DataContext dataContext)
        {
            this.dataContext = dataContext;
            Table = dataContext.Set<T>();
        }


        // Use this method to create.
        public T Create(T entity)
        {
            if(entity!=null)
            {
                Table.Add(entity);
                return entity;
            }
            return null;
        }

        // Use this method to delete.
        public void Delete(int id)
        {
            var entity = Read(id);
            if (entity != null)
            {
                Table.Remove(entity);
            }
        }

        // Use this method to return list of data.
        public IList<T> List()
        {
            return Table.ToList();
        }


        // Use this method to display specific data.
        public T Read(int id)
        {
            if(id > 0)
            {
                var entity = Table.SingleOrDefault(E => E.ID == id);
                return entity;
            }
            else
            {
                return null;
            }
        }

        // Use this method to update data.
        public void Update(T entity)
        {
            if (entity != null)
            {
                Table.Update(entity);
            }
        }
    }
}
