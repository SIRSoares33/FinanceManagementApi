using FinanceManagementApi.Models.Transaction;
using FinanceManagementApi.Repository.Transaction;
using FinanceManagementApi.Services.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TransactionController(ITransactionRepository repository, IBranchExists branchExists, ITransactionService service) : ControllerBase
    {
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionModel transactionModel)
        {
            try
            {
                await branchExists.BranchExistsAsync(transactionModel.BranchId);

                await repository.AddTransactionAsync(transactionModel);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateTransaction/{transactionId}")]
        public async Task<IActionResult> UpdateTransaction(int transactionId, [FromBody] TransactionModel transactionModel)
        {
            try
            {
                await branchExists.BranchExistsAsync(transactionModel.BranchId);

                await repository.UpdateTransactionAsync(transactionId, transactionModel);
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
                
                return Ok((await repository.GetAllTransactionsAsync()).Where(x => x.BranchId == branchId));
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
                TransactionStatistic statistic;
                
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
}