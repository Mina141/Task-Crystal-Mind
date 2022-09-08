using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_CrystalMind.Data;
using Task_CrystalMind.Models;
using Task_CrystalMind.Models.Repositories;

namespace Task_CrystalMind.Logic_Layer.Unit_of_work
{
    public class UnitOfWork : IUnitOfWork
    {
        IGenericRepostory<Customer> CustomerRepo;
        IGenericRepostory<Address> AddressRepo;
        private readonly DataContext dataContext;

        public UnitOfWork(IGenericRepostory<Customer> CustRepository , 
                            IGenericRepostory<Address> AdrRepository , DataContext dataContext)
        {
            CustomerRepo = CustRepository;
            AddressRepo = AdrRepository;
            this.dataContext = dataContext;
        }
        public IGenericRepostory<Address> GetAddressRepo()
        {
            return AddressRepo;
        }

        public IGenericRepostory<Customer> GetCustomerRepo()
        {
            return CustomerRepo;
        }

        public async Task Save()
        {
           await dataContext.SaveChangesAsync();
        }
    }
}
