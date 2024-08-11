using SuperMarket.Application.DTOs.CustomerDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface ICustomerService
    {
        Task<ResponseModel<List<CustomerGetDTO>>> GetAllCustomers();
        Task<ResponseModel<CustomerGetDTO>> GetCustomerById(int id);
        Task<ResponseModel<CustomerCreateDTO>> CreateCustomer(CustomerCreateDTO customerCreateDTO);
        Task<ResponseModel<bool>> UpdateCustomer(CustomerUpdateDTO cutomerUpdateDTO, int id);
        Task<ResponseModel<bool>> DeleteCustomer(int id);
        
    }
}
