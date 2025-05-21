using Finance.Dtos;
using FinanceManagementApi.Controllers.ControllerServices.Branch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BranchController(IBranchService service) : ControllerBase
{
    [HttpGet("GetAllBranchs")]
    public async Task<IActionResult> GetAllBranchsByUserId()
    {
        try
        {
            return Ok(await service.GetAllBranchsByUserIdAsync(User));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("CreateBranch")]
    public async Task<IActionResult> CreateBranch([FromBody] BranchDto dto)
    {
        await service.CreateBranchAsync(dto, User);
        return Created();
    }
    [HttpDelete("DeleteBranch/{branchId}")]
    public async Task<IActionResult> DeleteBranch(int branchId)
    {
        try
        {
            await service.DeleteBranchAsync(branchId);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return BadRequest("Id da branch não encontrado.");
        }
    }
}