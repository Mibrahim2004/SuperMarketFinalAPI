using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.OrderDetailsDTOs;
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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderDetailsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<OrderDetailsCreateDTO>> CreateOrderDetails(OrderDetailsCreateDTO orderdetailsCreateDTO)
        {
            ResponseModel<OrderDetailsCreateDTO> responseModel = new ResponseModel<OrderDetailsCreateDTO>() { Data = null, StatusCode = 400 };

            try
            {
                if (orderdetailsCreateDTO != null)
                {
                    var data = _mapper.Map<OrderDetails>(orderdetailsCreateDTO);
                    await _unitOfWork.GetRepository<OrderDetails>().AddAsync(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = orderdetailsCreateDTO;
                        responseModel.StatusCode = 201;
                    }
                    else
                    {
                        responseModel.StatusCode = 500;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> DeleteOrderDetails(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<OrderDetails>().GetByIDAsync(id);
                if (data != null)
                {
                    _unitOfWork.GetRepository<OrderDetails>().Remove(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = 200;
                    }
                }
                else
                {
                    responseModel.StatusCode = 400;
                }
            }
            catch
            {

                responseModel.Data = false;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<OrderDetailsGetDTO>>> GetAllOrderDetails()
        {
            ResponseModel<List<OrderDetailsGetDTO>> responseModel = new ResponseModel<List<OrderDetailsGetDTO>>() { Data = null, StatusCode = 500 };
            try
            {
                var orderdetails = await _unitOfWork.GetRepository<OrderDetails>().GetAll().ToListAsync();
                var orderdetailsDTOs = _mapper.Map<List<OrderDetailsGetDTO>>(orderdetails);
                responseModel.Data = orderdetailsDTOs;
                responseModel.StatusCode = 200;
            }
            catch
            {
                responseModel.Data = null;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<OrderDetailsGetDTO>> GetOrderDetailsById(int id)
        {
            ResponseModel<OrderDetailsGetDTO> responseModel = new ResponseModel<OrderDetailsGetDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitOfWork.GetRepository<OrderDetails>().GetByIDAsync(id);
                if (data != null)
                {
                    var orderdetailsDTOs = _mapper.Map<OrderDetailsGetDTO>(data);
                    responseModel.Data = orderdetailsDTOs;
                    responseModel.StatusCode = 200;
                }
                else
                {
                    responseModel.StatusCode = 500;
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<bool>> UpdateOrderDetails(OrderDetailsUpdateDTO orderdetailsUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<OrderDetails>().GetByIDAsync(id);
                if (data != null)
                {
                    var orderdetails = _mapper.Map(orderdetailsUpdateDTO, data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = 200;
                    }
                }
                else
                {
                    responseModel.StatusCode = 400;
                }
            }
            catch
            {

                responseModel.Data = false;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}