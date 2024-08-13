using SuperMarket.Application.DTOs.ProductDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface IProductService
    {
        Task<ResponseModel<List<ProductGetDTO>>> GetAllProducts();
        Task<ResponseModel<ProductGetDTO>> GetProductById(int id);
        Task<ResponseModel<ProductCreateDTO>> CreateProduct(ProductCreateDTO productCreateDTO);
        Task<ResponseModel<bool>> UpdateProduct(ProductUpdateDTO productUpdateDTO, int id);
        Task<ResponseModel<bool>> DeleteProduct(int id);
    }
}
