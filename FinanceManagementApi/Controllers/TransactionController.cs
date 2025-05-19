using AutoMapper;
using Finance.Dtos;
using FinanceManagementApi.Context.Tables;
using FinanceManagementApi.Repository.Transaction;
using FinanceManagementApi.Services.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TransactionController(ITransactionRepository repository, IBranchExists branchExists, ITransactionService service, IMapper mapper) : ControllerBase
{
    [HttpPost("AddTransaction")]
    public async Task<IActionResult> AddTransaction([FromBody] TransactionDto transactionModel)
    {
        try
        {
            await branchExists.BranchExistsAsync(transactionModel.BranchId);

            await repository.AddTransactionAsync(mapper.Map<TransactionTable>(transactionModel));
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("UpdateTransaction/{transactionId}")]
    public async Task<IActionResult> UpdateTransaction(int transactionId, [FromBody] TransactionDto transactionModel)
    {
        try
        {
            await branchExists.BranchExistsAsync(transactionModel.BranchId);

            await repository.UpdateTransactionAsync(transactionId, mapper.Map<TransactionTable>(transactionModel));
            return Ok();
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
            await repository.DeleteTransactionAsync(transactionId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetAllTransactions/{branchId}")]
    public async Task<IActionResult> GetAllTransactions(int branchId)
    {
        try
        {
            await branchExists.BranchExistsAsync(branchId);

            var transactions = mapper.Map<List<TransactionDto>>((await repository.GetAllTransactionsAsync()).Where(x => x.BranchId == branchId));
            
            return Ok(transactions);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetStatistics/{branchId}")]
    public async Task<IActionResult> GetStatisticsAsync(int branchId)
    {
        try
        {
            TransactionStatisticDto statistic;
            
            if (branchId is 0)
                statistic = service.GetTransactionStatistic(await repository.GetAllTransactionsAsync());
            else
            {
                await branchExists.BranchExistsAsync(branchId);

                statistic = service.GetTransactionStatistic((await repository.GetAllTransactionsAsync()).Where(x => x.BranchId == branchId).ToList());
            }
            
            return Ok(statistic);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}