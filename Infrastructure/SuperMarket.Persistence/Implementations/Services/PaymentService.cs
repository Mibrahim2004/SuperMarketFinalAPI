using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.PaymentDTOs;
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
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<PaymentCreateDTO>> CreatePayment(PaymentCreateDTO paymentCreateDTO)
        {
            ResponseModel<PaymentCreateDTO> responseModel = new ResponseModel<PaymentCreateDTO>() { Data = null, StatusCode = 400 };

            try
            {
                if (paymentCreateDTO != null)
                {
                    var data = _mapper.Map<Payment>(paymentCreateDTO);
                    await _unitOfWork.GetRepository<Payment>().AddAsync(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = paymentCreateDTO;
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

        public async Task<ResponseModel<bool>> DeletePayment(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Payment>().GetByIDAsync(id);
                if (data != null)
                {
                    _unitOfWork.GetRepository<Payment>().Remove(data);
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
            catch (Exception ex)
            {

                responseModel.Data = false;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<PaymentGetDTO>>> GetAllPayments()
        {
            ResponseModel<List<PaymentGetDTO>> responseModel = new ResponseModel<List<PaymentGetDTO>>() { Data = null, StatusCode = 500 };
            try
            {
                var payments = await _unitOfWork.GetRepository<Payment>().GetAll().ToListAsync();
                var paymentDTOs = _mapper.Map<List<PaymentGetDTO>>(payments);
                responseModel.Data = paymentDTOs;
                responseModel.StatusCode = 200;
            }
            catch (Exception ex)
            {
                responseModel.Data = null;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<PaymentGetDTO>> GetPaymentById(int id)
        {
            ResponseModel<PaymentGetDTO> responseModel = new ResponseModel<PaymentGetDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitOfWork.GetRepository<Payment>().GetByIDAsync(id);
                if (data != null)
                {
                    var paymentDTOs = _mapper.Map<PaymentGetDTO>(data);
                    responseModel.Data = paymentDTOs;
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
        public async Task<ResponseModel<bool>> UpdatePayment(PaymentUpdateDTO paymentUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Payment>().GetByIDAsync(id);
                if (data != null)
                {
                    var payment = _mapper.Map(paymentUpdateDTO, data);
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
            catch (Exception ex)
            {

                responseModel.Data = false;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}