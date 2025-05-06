using FinanceManagementApi.Models.Transaction;
using FinanceManagementApi.Repository.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TransactionController(ITransactionRepository repository): ControllerBase
    {
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionModel transactionModel)
        {
            await repository.AddTransactionAsync(transactionModel);
            return Created();
        }
        [HttpPut("UpdateTransaction/{transactionId}")]
        public async Task<IActionResult> UpdateTransaction(int transactionId, [FromBody] TransactionModel transactionModel)
        {
            try
            {
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
    }
}