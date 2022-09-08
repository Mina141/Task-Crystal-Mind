using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_CrystalMind.DTOES;
using Task_CrystalMind.Logic_Layer.Unit_of_work;
using Task_CrystalMind.Models;

namespace Task_CrystalMind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //we did the ResaultDto to Consolidation of the response to the result
        ResaultDto Resault = new ResaultDto();
        public IUnitOfWork _UnitOfWork { get; }

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        // Use this method to get all customer.

        [HttpGet("GeTAll")]

        public ResaultDto GetAll()
        {
            try
            {
                var customers = _UnitOfWork.GetCustomerRepo().List();
                if(customers == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "Not Found Any Customer";
                    Resault.Data = null;
                    return Resault;
                }

                Resault.IsSuccess = true;
                Resault.Message = "Success";
                Resault.Data = customers;
                return Resault;
            }
            catch(Exception error)
            {
                Resault.IsSuccess = false;
                Resault.Message = error.Message;
                Resault.Data = null;
                return Resault;
            }
        }

        // Use this method to get customer by id.

        [HttpGet("GetByID/{id}")]

        public ResaultDto GetByID(int id)
        {
            try
            {
                if(id <= 0)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "invalaid id";
                    Resault.Data = null;
                    return Resault;
                }
                var customer = _UnitOfWork.GetCustomerRepo().Read(id);
                if (customer == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "Not Found this Customer id";
                    Resault.Data = null;
                    return Resault;
                }

                Resault.IsSuccess = true;
                Resault.Message = "Success";
                Resault.Data = customer;
                return Resault;
            }
            catch (Exception error)
            {
                Resault.IsSuccess = false;
                Resault.Message = error.Message;
                Resault.Data = null;
                return Resault;
            }
        }

        // Use this method to add add customer.

        [HttpPost("AddCustomer")]

        public async Task<ResaultDto> AddCustomer(Customer customer)
        {
            try
            {
                if ( customer == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "invalaid object";
                    Resault.Data = null;
                    return Resault;
                }
                if(customer.Addresses == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "invalaid object";
                    Resault.Data = null;
                    return Resault;
                }

                _UnitOfWork.GetCustomerRepo().Create(customer);
                await _UnitOfWork.Save();

                
                Resault.IsSuccess = true;
                Resault.Message = "Success";
                Resault.Data = customer;
                return Resault;
            }
            catch (Exception error)
            {
                Resault.IsSuccess = false;
                Resault.Message = error.Message;
                Resault.Data = null;
                return Resault;
            }
        }

        // Use this method to update customer.

        [HttpPut("UpdateCustomer")]

        public async Task<ResaultDto> UpdateCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "invalaid object";
                    Resault.Data = null;
                    return Resault;
                }
                _UnitOfWork.GetCustomerRepo().Update(customer);
                await _UnitOfWork.Save();

                Resault.IsSuccess = true;
                Resault.Message = "Success Update";
                Resault.Data = customer;
                return Resault;
            }
            catch (Exception error)
            {
                Resault.IsSuccess = false;
                Resault.Message = error.Message;
                Resault.Data = null;
                return Resault;
            }
        }

        // Use this method to delete customer.

        [HttpDelete("Delete/{id}")]

        public async Task<ResaultDto> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "invalaid id";
                    Resault.Data = null;
                    return Resault;
                }
                _UnitOfWork.GetCustomerRepo().Delete(id);
                await _UnitOfWork.Save();
                
                Resault.IsSuccess = true;
                Resault.Message = "Success delete";
                Resault.Data = true;
                return Resault;
            }
            catch (Exception error)
            {
                Resault.IsSuccess = false;
                Resault.Message = error.Message;
                Resault.Data = null;
                return Resault;
            }
        }

    }
}
