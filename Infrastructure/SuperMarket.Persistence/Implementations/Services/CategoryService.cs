using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.CategoryDTOs;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<CategoryCreateDTO>> CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            ResponseModel<CategoryCreateDTO> responseModel = new ResponseModel<CategoryCreateDTO>() { Data = null, StatusCode = 400 };

            try
            {
                if (categoryCreateDTO != null)
                {
                    var data = _mapper.Map<Category>(categoryCreateDTO);
                    await _unitOfWork.GetRepository<Category>().AddAsync(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = categoryCreateDTO;
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

        public async Task<ResponseModel<bool>> DeleteCategory(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Category>().GetByIDAsync(id);
                if (data != null)
                {
                    _unitOfWork.GetRepository<Category>().Remove(data);
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

        public async Task<ResponseModel<List<CategoryGetDTO>>> GetAllCategories()
        {
            ResponseModel<List<CategoryGetDTO>> responseModel = new ResponseModel<List<CategoryGetDTO>>() { Data = null, StatusCode = 500 };
            try
            {
                var categories = await _unitOfWork.GetRepository<Category>().GetAll().ToListAsync();
                var categoryDTOs = _mapper.Map<List<CategoryGetDTO>>(categories);
                responseModel.Data = categoryDTOs;
                responseModel.StatusCode = 200;
            }
            catch (Exception ex)
            {
                responseModel.Data = null;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<CategoryGetDTO>> GetCategoryById(int id)
        {
            ResponseModel<CategoryGetDTO> responseModel = new ResponseModel<CategoryGetDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitOfWork.GetRepository<Category>().GetByIDAsync(id);
                if (data != null)
                {
                    var categoryDTOs = _mapper.Map<CategoryGetDTO>(data);
                    responseModel.Data = categoryDTOs;
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
        public async Task<ResponseModel<bool>> UpdateCategory(CategoryUpdateDTO categoryUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Category>().GetByIDAsync(id);
                if (data != null)
                {
                    var category = _mapper.Map(categoryUpdateDTO, data);
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