using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_CrystalMind.Models;
using Task_CrystalMind.Models.Repositories;

namespace Task_CrystalMind.Logic_Layer.Unit_of_work
{
    public interface IUnitOfWork
    {
        IGenericRepostory<Customer> GetCustomerRepo();
        IGenericRepostory<Address> GetAddressRepo();
        Task Save();
    }
}
