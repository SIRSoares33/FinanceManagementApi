using System.Security.Claims;
using AutoMapper;
using Finance.Dtos;
using FinanceManagementApi.Context.Tables;
using FinanceManagementApi.Repository;
using FinanceManagementApi.Services.UserIdentity;

namespace FinanceManagementApi.Controllers.ControllerServices.Branch;

public class BranchService(IRepository repository, IMapper mapper) : IBranchService
{
    public async Task<List<BranchDto>> GetAllBranchsByUserIdAsync(ClaimsPrincipal user)
    {
        var branchs = await repository.GetCollectionFromEntityAsync<UserTable, BranchTable>(UserIdentity.GetUserId(user), u => u.Branches);

        return mapper.Map<List<BranchDto>>(branchs);
    }
    public async Task CreateBranchAsync(BranchDto dto, ClaimsPrincipal user)
    {
        dto.UserId = UserIdentity.GetUserId(user);

        await repository.CreateAsync(mapper.Map<BranchTable>(dto));
    }
    public async Task DeleteBranchAsync(int id)
        => await repository.DeleteAsync<BranchTable>(id);
}
