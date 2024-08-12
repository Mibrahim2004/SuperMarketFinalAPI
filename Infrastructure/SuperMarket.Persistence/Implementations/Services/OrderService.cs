using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.CustomerDTOs;
using SuperMarket.Application.DTOs.OrderDTOs;
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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<OrderCreateDTO>> CreateOrder(OrderCreateDTO orderCreateDTO)
        {
            ResponseModel<OrderCreateDTO> responseModel = new ResponseModel<OrderCreateDTO>() { Data = null, Status = 400 };

            try
            {
                if (orderCreateDTO != null)
                {
                    var data = _mapper.Map<Order>(orderCreateDTO);
                    await _unitOfWork.GetRepository<Order>().AddAsync(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = orderCreateDTO;
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

        public async Task<ResponseModel<bool>> DeleteOrder(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, Status = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Order>().GetByIDAsync(id);
                if (data != null)
                {
                    _unitOfWork.GetRepository<Order>().Remove(data);
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

        public async Task<ResponseModel<List<OrderGetDTO>>> GetAllOrders()
        {
            ResponseModel<List<OrderGetDTO>> responseModel = new ResponseModel<List<OrderGetDTO>>() { Data = null, Status = 500 };
            try
            {
                var orders = await _unitOfWork.GetRepository<Order>().GetAll().ToListAsync();//???
                var orderDTOs = _mapper.Map<List<OrderGetDTO>>(orders);
                responseModel.Data = orderDTOs;
                responseModel.Status = 200;
            }
            catch (Exception ex)
            {
                responseModel.Data = null;
                responseModel.Status = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<OrderGetDTO>> GetOrderById(int id)
        {
            ResponseModel<OrderGetDTO> responseModel = new ResponseModel<OrderGetDTO>()
            {
                Data = null,
                Status = 400
            };
            try
            {
                var data = await _unitOfWork.GetRepository<Order>().GetByIDAsync(id);
                if (data != null)
                {
                    var orderDTOs = _mapper.Map<OrderGetDTO>(data);
                    responseModel.Data = orderDTOs;
                    responseModel.Status = 200;
                }
                else
                {
                    responseModel.Status = 500;
                }
            }
            catch
            {
                responseModel.Status = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<bool>> UpdateOrder(OrderUpdateDTO orderUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, Status = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Order>().GetByIDAsync(id);
                if (data != null)
                {
                    var order = _mapper.Map(orderUpdateDTO, data);
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
