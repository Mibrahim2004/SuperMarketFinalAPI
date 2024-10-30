using SuperMarket.Application.DTOs.PaymentDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface IPaymentService
    {
        Task<ResponseModel<List<PaymentGetDTO>>> GetAllPayments();
        Task<ResponseModel<PaymentGetDTO>> GetPaymentById(int id);
        Task<ResponseModel<PaymentCreateDTO>> CreatePayment(PaymentCreateDTO paymentCreateDTO);
        Task<ResponseModel<bool>> UpdatePayment(PaymentUpdateDTO paymentUpdateDTO, int id);
        Task<ResponseModel<bool>> DeletePayment(int id);
    }
}
