using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.InventoryDTOs;
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
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InventoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<InventoryCreateDTO>> CreateInventory(InventoryCreateDTO inventoryCreateDTO)
        {
            ResponseModel<InventoryCreateDTO> responseModel = new ResponseModel<InventoryCreateDTO>() { Data = null, StatusCode = 400 };

            try
            {
                if (inventoryCreateDTO != null)
                {
                    var data = _mapper.Map<Inventory>(inventoryCreateDTO);
                    await _unitOfWork.GetRepository<Inventory>().AddAsync(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = inventoryCreateDTO;
                        responseModel.StatusCode = 201;
                    }
                    else
                    {
                        responseModel.StatusCode = 500;
                    }
                }
            }
            catch 
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> DeleteInventory(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Inventory>().GetByIDAsync(id);
                if (data != null)
                {
                    _unitOfWork.GetRepository<Inventory>().Remove(data);
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
            catch 
            {

                responseModel.Data = false;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<InventoryGetDTO>>> GetAllInventories()
        {
            ResponseModel<List<InventoryGetDTO>> responseModel = new ResponseModel<List<InventoryGetDTO>>() { Data = null, StatusCode = 500 };
            try
            {
                var inventories = await _unitOfWork.GetRepository<Inventory>().GetAll().ToListAsync();
                var inventoryDTOs = _mapper.Map<List<InventoryGetDTO>>(inventories);
                responseModel.Data = inventoryDTOs;
                responseModel.StatusCode = 200;
            }
            catch 
            {
                responseModel.Data = null;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<InventoryGetDTO>> GetInventoryById(int id)
        {
            ResponseModel<InventoryGetDTO> responseModel = new ResponseModel<InventoryGetDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitOfWork.GetRepository<Inventory>().GetByIDAsync(id);
                if (data != null)
                {
                    var inventoryDTOs = _mapper.Map<InventoryGetDTO>(data);
                    responseModel.Data = inventoryDTOs;
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
        public async Task<ResponseModel<bool>> UpdateInventory(InventoryUpdateDTO inventoryUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Inventory>().GetByIDAsync(id);
                if (data != null)
                {
                    var inventory = _mapper.Map(inventoryUpdateDTO, data);
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
            catch 
            {

                responseModel.Data = false;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}