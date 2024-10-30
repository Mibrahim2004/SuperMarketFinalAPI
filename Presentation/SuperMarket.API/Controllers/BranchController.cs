using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.DTOs.BranchDTOs;
using SuperMarket.Application.Interfaces.IServices;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _branchService.GetAllBranches();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]

        public async Task<IActionResult> GetById(int id)
        {
            var response = await _branchService.GetBranchById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Create(BranchCreateDTO createBranchDTO)
        {
            var response = await _branchService.CreateBranch(createBranchDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _branchService.DeleteBranch(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Update(BranchUpdateDTO updateBranchDTO, int id)
        {
            var response = await _branchService.UpdateBranch(updateBranchDTO, id);
            return StatusCode(response.StatusCode, response);
        }
    }
}