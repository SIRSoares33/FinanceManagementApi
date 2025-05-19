using AutoMapper;
using Finance.Dtos;
using FinanceManagementApi.Context.Tables;
using FinanceManagementApi.Repository.Branch;
using FinanceManagementApi.Services.UserIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BranchController(IBranchRepository repository, IMapper mapper) : ControllerBase
{
    [HttpGet("GetAllBranchs")]
    public async Task<IActionResult> GetAllBranchsByUserId()
    {
        try
        {                
            var branchs = await repository.GetAllBranchsByUserIdAsync(UserIdentity.GetUserId(User));
            
            return Ok(mapper.Map<List<BranchDto>>(branchs));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("CreateBranch")]
    public async Task<IActionResult> CreateBranch([FromBody] BranchDto model)
    {
        model.UserId = UserIdentity.GetUserId(User);
        
        await repository.CreateBranchAsync(mapper.Map<BranchTable>(model));
        return Created();
    }
    [HttpPut("UpdateBranch/{branchId}")]
    public async Task<IActionResult> UpdateBranch(int branchId, [FromBody] BranchDto model)
    {
        try
        {
            model.UserId = UserIdentity.GetUserId(User);

            await repository.UpdateBranchAsync(branchId, mapper.Map<BranchTable>(model));
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