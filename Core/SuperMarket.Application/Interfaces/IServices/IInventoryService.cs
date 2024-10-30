using SuperMarket.Application.DTOs.InventoryDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface IInventoryService
    {
        Task<ResponseModel<List<InventoryGetDTO>>> GetAllInventories();
        Task<ResponseModel<InventoryGetDTO>> GetInventoryById(int id);
        Task<ResponseModel<InventoryCreateDTO>> CreateInventory(InventoryCreateDTO inventoryCreateDTO);
        Task<ResponseModel<bool>> UpdateInventory(InventoryUpdateDTO inventoryUpdateDTO, int id);
        Task<ResponseModel<bool>> DeleteInventory(int id);
    }
}
