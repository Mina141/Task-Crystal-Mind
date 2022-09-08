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
    public class AddressController : ControllerBase
    {
        //we did the ResaultDto to Consolidation of the response to the result
        ResaultDto Resault = new ResaultDto();
        public IUnitOfWork _UnitOfWork { get; }

        public AddressController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        // Use this method to get all addresses.

        [HttpGet("GeTAllAddresses")]

        public ResaultDto GetAllAddresses()
        {
            try
            {
                var addresses = _UnitOfWork.GetAddressRepo().List();
                if (addresses == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "Not Found Any Address";
                    Resault.Data = null;
                    return Resault;
                }

                Resault.IsSuccess = true;
                Resault.Message = "Success";
                Resault.Data = addresses;
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

        // Use this method to get  addresses by address id .

        [HttpGet("GetAddByID/{id}")]

        public ResaultDto GetAddByID(int id)
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
                var address = _UnitOfWork.GetAddressRepo().Read(id);
                if (address == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "Not Found this Address id";
                    Resault.Data = null;
                    return Resault;
                }

                Resault.IsSuccess = true;
                Resault.Message = "Success";
                Resault.Data = address;
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

        // Use this method to add addresses.

        [HttpPost("AddAddress")]

        public async Task<ResaultDto> AddAddress(Address address)
        {
            try
            {
                if (address == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "invalaid object";
                    Resault.Data = null;
                    return Resault;
                }

                _UnitOfWork.GetAddressRepo().Create(address);
                await _UnitOfWork.Save();


                Resault.IsSuccess = true;
                Resault.Message = "Success";
                Resault.Data = address;
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

        // Use this method to update  addresses.

        [HttpPut("UpdateAddress")]

        public async Task<ResaultDto> UpdateAddress(Address address)
        {
            try
            {
                if (address == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "invalaid object";
                    Resault.Data = null;
                    return Resault;
                }
                _UnitOfWork.GetAddressRepo().Update(address);
                await _UnitOfWork.Save();

                Resault.IsSuccess = true;
                Resault.Message = "Success Update";
                Resault.Data = address;
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

        // Use this method to delete  addresses by id.

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
                _UnitOfWork.GetAddressRepo().Delete(id);
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

        // Use this method to get all addresses by customer id.

        [HttpGet("GetAddressByCustID/{id}")]

        public ResaultDto GetAddressByCustID(int id)
        {
            try
            {
                if (id <= 0)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "invalaid Customer id";
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

                var Addresses = _UnitOfWork.GetAddressRepo().List().Where(adr => adr.CustomerID == id);
                if (Addresses == null)
                {
                    Resault.IsSuccess = false;
                    Resault.Message = "Not Found Any Addresses For this Customer id";
                    Resault.Data = null;
                    return Resault;
                }

                Resault.IsSuccess = true;
                Resault.Message = "Success";
                Resault.Data = Addresses;
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
