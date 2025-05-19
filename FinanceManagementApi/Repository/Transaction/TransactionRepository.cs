using FinanceManagementApi.Context;
using FinanceManagementApi.Context.Tables;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Repository.Transaction;

public class TransactionRepository(IContext context) : ITransactionRepository
{
    #region Methods
    // ITransactionRepository
    public async Task AddTransactionAsync(TransactionTable transactionModel)
        { await context.Transactions.AddAsync(transactionModel); await context.Save(); }
    
    public async Task DeleteTransactionAsync(int transactionId)
        { context.Transactions.Remove(await GetTransactionByIdAsync(transactionId)); await context.Save(); }

    public async Task UpdateTransactionAsync(int transactionId, TransactionTable transactionModel)
    {
        await DeleteTransactionAsync(transactionId);
        
        transactionModel.Id = transactionId;
        
        await context.Transactions.AddAsync(transactionModel);
        await context.Save();
    }

    public async Task<List<TransactionTable>> GetAllTransactionsAsync()
        => await context.Transactions.ToListAsync();

    private async Task<TransactionTable> GetTransactionByIdAsync(int transactionId)
        => await context.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId) 
            ?? throw new Exception("Transação não encontrada.");
    #endregion
}