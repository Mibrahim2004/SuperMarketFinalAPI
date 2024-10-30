using SuperMarket.Application.DTOs.BranchDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface IBranchService
    {
        Task<ResponseModel<List<BranchGetDTO>>> GetAllBranches();
        Task<ResponseModel<BranchGetDTO>> GetBranchById(int id);
        Task<ResponseModel<BranchCreateDTO>> CreateBranch(BranchCreateDTO branchCreateDTO);
        Task<ResponseModel<bool>> UpdateBranch(BranchUpdateDTO branchUpdateDTO, int id);
        Task<ResponseModel<bool>> DeleteBranch(int id);
    }
}
