using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.ProductDTOs;
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
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<ProductCreateDTO>> CreateProduct(ProductCreateDTO productCreateDTO)
        {
            ResponseModel<ProductCreateDTO> responseModel = new ResponseModel<ProductCreateDTO>() { Data = null, Status = 400 };

            try
            {
                if (productCreateDTO != null)
                {
                    var data = _mapper.Map<Product>(productCreateDTO);
                    await _unitOfWork.GetRepository<Product>().AddAsync(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = productCreateDTO;
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

        public async Task<ResponseModel<bool>> DeleteProduct(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, Status = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Product>().GetByIDAsync(id);
                if (data != null)
                {
                    _unitOfWork.GetRepository<Product>().Remove(data);
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

        public async Task<ResponseModel<List<ProductGetDTO>>> GetAllPrducts()
        {
            ResponseModel<List<ProductGetDTO>> responseModel = new ResponseModel<List<ProductGetDTO>>() { Data = null, Status = 500 };
            try
            {
                var products = await _unitOfWork.GetRepository<Product>().GetAll().ToListAsync();
                var productDTOs = _mapper.Map<List<ProductGetDTO>>(products);
                responseModel.Data = productDTOs;
                responseModel.Status = 200;
            }
            catch (Exception ex)
            {
                responseModel.Data = null;
                responseModel.Status = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<ProductGetDTO>> GetProductById(int id)
        {
            ResponseModel<ProductGetDTO> responseModel = new ResponseModel<ProductGetDTO>()
            {
                Data = null,
                Status = 400
            };
            try
            {
                var data = await _unitOfWork.GetRepository<Product>().GetByIDAsync(id);
                if (data != null)
                {
                    var productDTOs = _mapper.Map<ProductGetDTO>(data);
                    responseModel.Data = productDTOs;
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
        public async Task<ResponseModel<bool>> UpdateProduct(ProductUpdateDTO productUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, Status = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Product>().GetByIDAsync(id);
                if (data != null)
                {
                    var product = _mapper.Map(productUpdateDTO, data);
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