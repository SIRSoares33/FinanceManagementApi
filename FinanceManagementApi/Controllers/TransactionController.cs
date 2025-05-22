using Finance.Dtos;
using FinanceManagementApi.Controllers.ControllerServices.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TransactionController(ITransactionService service) : ControllerBase
{
    [HttpPost("AddTransaction")]
    public async Task<IActionResult> AddTransaction([FromBody] TransactionDto dto)
    {
        try
        {
            await service.CreateTransactionAsync(dto);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("DeleteTransaction/{transactionId}")]
    public async Task<IActionResult> DeleteTransaction(int transactionId)
    {
        try
        {
            await service.DeleteTransaction(transactionId);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return BadRequest("Transa��o n�o encontrada.");
        }
    }
    [HttpGet("GetAllBranchTransactions/{branchId}")]
    public async Task<IActionResult> GetAllTransactions(int branchId)
    {
        try
        {   
            return Ok(await service.GetAllBranchTransactionsAsync(branchId));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetBranchStatistics/{branchId}")]
    public async Task<IActionResult> GetStatisticsAsync(int branchId)
    {
        try
        {
            return Ok(service.GetTransactionStatistic(await service.GetAllBranchTransactionsAsync(branchId)));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetAllStatistics")]
    public async Task<IActionResult> GetAllStatisticsAsync()
    {
        var transactions = await service.GetAllUserTransactionsAsync(User);
        return Ok(service.GetTransactionStatistic(transactions));
    }
}