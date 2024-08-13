using SuperMarket.Application.DTOs.OrderDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<ResponseModel<List<OrderGetDTO>>> GetAllOrders();
        Task<ResponseModel<OrderGetDTO>> GetOrderById(int id);
        Task<ResponseModel<OrderCreateDTO>> CreateOrder(OrderCreateDTO orderCreateDTO);
        Task<ResponseModel<bool>> UpdateOrder(OrderUpdateDTO orderUpdateDTO, int id);
        Task<ResponseModel<bool>> DeleteOrder(int id);
    }
}
