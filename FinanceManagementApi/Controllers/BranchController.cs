using FinanceManagementApi.Models.Branch;
using FinanceManagementApi.Repository.Branch;
using FinanceManagementApi.Services.UserIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BranchController(IBranchRepository repository) : ControllerBase
    {
        [HttpGet("GetAllBranchs")]
        public async Task<IActionResult> GetAllBranchsByUserId()
        {
            try
            {                
                var branchs = await repository.GetAllBranchsByUserIdAsync(UserIdentity.GetUserId(User));
                
                return Ok(branchs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateBranch")]
        public async Task<IActionResult> CreateBranch([FromBody] BranchModel branchModel)
        {
            branchModel.UserId = UserIdentity.GetUserId(User);
            
            await repository.CreateBranchAsync(branchModel);
            return Created();
        }
        [HttpPatch("UpdateBranch/{branchId}")]
        public async Task<IActionResult> UpdateBranch(int branchId, [FromBody] BranchModel branchModel)
        {
            try
            {
                branchModel.UserId = UserIdentity.GetUserId(User);

                await repository.UpdateBranchAsync(branchId, branchModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteBranch/{branchId}")]
        public async Task<IActionResult> DeleteBranch(int branchId)
        {
            try
            {
                await repository.DeleteBranchAsync(branchId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}