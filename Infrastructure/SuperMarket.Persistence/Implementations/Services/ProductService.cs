using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.ProductDTOs;
using SuperMarket.Application.Interfaces.IServices;
using SuperMarket.Application.Interfaces.IUnitOfWorks;
using SuperMarket.Application.Models;
using SuperMarket.Domain.Entities;
using SuperMarket.Persistence.Implementations.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Services
{
    public class ProductService : IProductService
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
            ResponseModel<ProductCreateDTO> responseModel = new ResponseModel<ProductCreateDTO>() { Data = null, StatusCode = 400 };

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

        public async Task<ResponseModel<bool>> DeleteProduct(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
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

        public async Task<ResponseModel<List<ProductGetDTO>>> GetAllProducts()
        {
            ResponseModel<List<ProductGetDTO>> responseModel = new ResponseModel<List<ProductGetDTO>>() { Data = null, StatusCode = 500 };
            try
            {
                var products = await _unitOfWork.GetRepository<Product>().GetAll().ToListAsync();
                var productDTOs = _mapper.Map<List<ProductGetDTO>>(products);
                responseModel.Data = productDTOs;
                responseModel.StatusCode = 200;
            }
            catch (Exception ex)
            {
                responseModel.Data = null;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<ProductGetDTO>> GetProductById(int id)
        {
            ResponseModel<ProductGetDTO> responseModel = new ResponseModel<ProductGetDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitOfWork.GetRepository<Product>().GetByIDAsync(id);
                if (data != null)
                {
                    var productDTOs = _mapper.Map<ProductGetDTO>(data);
                    responseModel.Data = productDTOs;
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
        public async Task<ResponseModel<bool>> UpdateProduct(ProductUpdateDTO productUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
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
        public async Task<ResponseModel<List<ProductGetDTO>>> MostExpensiveProducts()
        {
            ResponseModel<List<ProductGetDTO>> responseModel = new ResponseModel<List<ProductGetDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var products = await _unitOfWork.GetRepository<Product>().GetAll().OrderByDescending(x => x.Price)
                    .ToListAsync();
                var productsdto = _mapper.Map<List<ProductGetDTO>>(products);
                responseModel.Data = productsdto;
                responseModel.StatusCode = 200;
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}