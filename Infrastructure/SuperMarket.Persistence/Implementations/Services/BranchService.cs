using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.BranchDTOs;
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
     public class BranchService : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BranchService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<BranchCreateDTO>> CreateBranch(BranchCreateDTO branchCreateDTO)
        {
            ResponseModel<BranchCreateDTO> responseModel = new ResponseModel<BranchCreateDTO>() { Data = null, StatusCode = 400 };

            try
            {
                if (branchCreateDTO != null)
                {
                    var data = _mapper.Map<Branch>(branchCreateDTO);
                    await _unitOfWork.GetRepository<Branch>().AddAsync(data);
                    int rowsAffected = await _unitOfWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = branchCreateDTO;
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

        public async Task<ResponseModel<bool>> DeleteBranch(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Branch>().GetByIDAsync(id);
                if (data != null)
                {
                    _unitOfWork.GetRepository<Branch>().Remove(data);
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

        public async Task<ResponseModel<List<BranchGetDTO>>> GetAllBranches()
        {
            ResponseModel<List<BranchGetDTO>> responseModel = new ResponseModel<List<BranchGetDTO>>() { Data = null, StatusCode = 500 };
            try
            {
                var branches = await _unitOfWork.GetRepository<Branch>().GetAll().ToListAsync();
                var branchDTOs = _mapper.Map<List<BranchGetDTO>>(branches);
                responseModel.Data = branchDTOs;
                responseModel.StatusCode = 200;
            }
            catch
            {
                responseModel.Data = null;
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
        public async Task<ResponseModel<BranchGetDTO>> GetBranchById(int id)
        {
            ResponseModel<BranchGetDTO> responseModel = new ResponseModel<BranchGetDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitOfWork.GetRepository<Branch>().GetByIDAsync(id);
                if (data != null)
                {
                    var branchDTOs = _mapper.Map<BranchGetDTO>(data);
                    responseModel.Data = branchDTOs;
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
        public async Task<ResponseModel<bool>> UpdateBranch(BranchUpdateDTO branchUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() { Data = false, StatusCode = 500 };
            try
            {
                var data = await _unitOfWork.GetRepository<Branch>().GetByIDAsync(id);
                if (data != null)
                {
                    var branch = _mapper.Map(branchUpdateDTO, data);
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