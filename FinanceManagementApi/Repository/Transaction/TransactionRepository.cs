using FinanceManagementApi.Context;
using FinanceManagementApi.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Repository.Transaction
{
    public class TransactionRepository(IContext context) : ITransactionRepository
    {
        #region Methods
        // ITransactionRepository
        public async Task AddTransactionAsync(TransactionModel transactionModel)
            { await context.Transactions.AddAsync(transactionModel); await context.Save(); }
        
        public async Task DeleteTransactionAsync(int transactionId)
            { context.Transactions.Remove(await GetTransactionByIdAsync(transactionId)); await context.Save(); }

        public async Task UpdateTransactionAsync(int transactionId, TransactionModel transactionModel)
        {
            await DeleteTransactionAsync(transactionId);
            
            transactionModel.Id = transactionId;
            
            await context.Transactions.AddAsync(transactionModel);
            await context.Save();
        }

        public async Task<List<TransactionModel>> GetAllTransactionsAsync()
            => await context.Transactions.ToListAsync();

        private async Task<TransactionModel> GetTransactionByIdAsync(int transactionId)
            => await context.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId) 
                ?? throw new Exception("Transação não encontrada.");
        #endregion
    }
}