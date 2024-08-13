using SuperMarket.Application.DTOs.CategoryDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<ResponseModel<List<CategoryGetDTO>>> GetAllCategories();
        Task<ResponseModel<CategoryGetDTO>> GetCategoryById(int id);
        Task<ResponseModel<CategoryCreateDTO>> CreateCategory(CategoryCreateDTO categoryCreateDTO);
        Task<ResponseModel<bool>> UpdateCategory(CategoryUpdateDTO categoryUpdateDTO, int id);
        Task<ResponseModel<bool>> DeleteCategory(int id);
    }
}
