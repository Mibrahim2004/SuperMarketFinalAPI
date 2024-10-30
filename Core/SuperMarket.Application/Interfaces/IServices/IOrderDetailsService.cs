using SuperMarket.Application.DTOs.OrderDetailsDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface IOrderDetailsService
    {
        Task<ResponseModel<List<OrderDetailsGetDTO>>> GetAllOrderDetails();
        Task<ResponseModel<OrderDetailsGetDTO>> GetOrderDetailsById(int id);
        Task<ResponseModel<OrderDetailsCreateDTO>> CreateOrderDetails(OrderDetailsCreateDTO orderDetailsCreateDTO);
        Task<ResponseModel<bool>> UpdateOrderDetails(OrderDetailsUpdateDTO orderDetailsUpdateDTO, int id);
        Task<ResponseModel<bool>> DeleteOrderDetails(int id);
    }
}
