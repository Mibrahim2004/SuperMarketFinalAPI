using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.CustomerDTOs;
using SuperMarket.Application.Interfaces.IServices;
using SuperMarket.Application.Interfaces.IUnitOfWorks;
using SuperMarket.Application.Models;
using SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Services
{
    // GetById yazmaq
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<CustomerCreateDTO>> CreateCustomer(CustomerCreateDTO customerCreateDTO)
        {
            ResponseModel<CustomerCreateDTO> responseModel = new ResponseModel<CustomerCreateDTO>() { Data = null, Status = 400 };

            try
            {
                if (customerCreateDTO != null)
                {
                    var data = _mapper.Map<Customer>(customerCreateDTO);
                    await _unitOfWork.GetRepository<Customer>().AddAsync(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = customerCreateDTO;
                        responseModel.Status = 201;
                    }
                    else
                    {
                        responseModel.Status = 500;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.Status = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> DeleteCustomer(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, Status = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Customer>().GetByIDAsync(id);
                if (data != null)
                {
                    _unitOfWork.GetRepository<Customer>().Remove(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = true;
                        responseModel.Status = 200;
                    }
                }
                else
                {
                    responseModel.Status = 400;
                }
            }
            catch (Exception ex)
            {

                responseModel.Data = false;
                responseModel.Status = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<CustomerGetDTO>>> GetAllCustomers()
        {
            ResponseModel<List<CustomerGetDTO>> responseModel = new ResponseModel<List<CustomerGetDTO>>() { Data = null, Status = 500 };
            try
            {
                var customers = await _unitOfWork.GetRepository<Customer>().GetAll().ToListAsync();//???
                var customerDTOs = _mapper.Map<List<CustomerGetDTO>>(customers);
                responseModel.Data = customerDTOs;
                responseModel.Status = 200;
            }
            catch (Exception ex)
            {
                responseModel.Data = null;
                responseModel.Status = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<bool>> UpdateCustomer(CustomerUpdateDTO customerUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, Status = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Customer>().GetByIDAsync(id);
                if (data != null)
                {
                    var customer = _mapper.Map(customerUpdateDTO, data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = true;
                        responseModel.Status = 200;
                    }
                }
                else
                {
                    responseModel.Status = 400;
                }
            }
            catch (Exception ex)
            {

                responseModel.Data = false;
                responseModel.Status = 500;
            }
            return responseModel;
        }
    }
}