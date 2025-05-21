using System.Security.Claims;
using AutoMapper;
using Finance.Dtos;
using FinanceManagementApi.Context.Tables;
using FinanceManagementApi.Repository;
using FinanceManagementApi.Services.UserIdentity;

namespace FinanceManagementApi.Controllers.ControllerServices.Transaction;

public class TransactionService(IRepository repository, IMapper mapper) : ITransactionService
{
    public async Task CreateTransactionAsync(TransactionDto dto)
    {
        if (!await repository.ExistsAsync<BranchTable>(x => x.Id == dto.BranchId)) throw new Exception("Branch n�o existe."); 

        await repository.CreateAsync(mapper.Map<TransactionTable>(dto));
    }
    public TransactionStatisticDto GetTransactionStatistic(List<TransactionDto> transactions)
    { 
        var entry   = transactions.Where(x => x.IsEntry).Sum(x => x.Amount);
        var expense = transactions.Where(x => !x.IsEntry).Sum(x => x.Amount);

        return new ()
        {
            Entry   = entry,
            Expense = expense,
            Balance = entry - expense
        };
    }
    public async Task<List<TransactionDto>> GetAllUserTransactionsAsync(ClaimsPrincipal user)
    {
        var userBranches = await repository.GetCollectionFromEntityAsync<UserTable, BranchTable>(UserIdentity.GetUserId(user), x => x.Branches);

        var allTransactions = new List<TransactionTable>();

        foreach (var branch in userBranches)
        {
            var transactions = await repository.GetCollectionFromEntityAsync<BranchTable, TransactionTable>
            (
                branch.Id,
                b => b.Transactions
            );

            allTransactions.AddRange(transactions);
        }

        return mapper.Map<List<TransactionDto>>(allTransactions);
    }

    public async Task<List<TransactionDto>> GetAllBranchTransactionsAsync(int branchId)
    {
        if (!await repository.ExistsAsync<BranchTable>(x => x.Id == branchId))
            throw new Exception("Branch não existe.");

        var transactions = await repository.GetCollectionFromEntityAsync<BranchTable, TransactionTable>(
            branchId,
            x => x.Transactions
        );

        return mapper.Map<List<TransactionDto>>(transactions);
    }

    public async Task DeleteTransaction(int id)
        => await repository.DeleteAsync<TransactionTable>(id);
}