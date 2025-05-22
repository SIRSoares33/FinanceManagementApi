using AutoMapper;
using Finance.Dtos;
using FinanceManagementApi.Context.Tables;

namespace FinanceManagementApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LoginDto, UserTable>();
        CreateMap<RegisterDto, UserTable>();

        CreateMap<BranchDto, BranchTable>()
            .ForMember(dest => dest.User, opt => opt.Ignore()) // evita ciclo
            .ForMember(dest => dest.Transactions, opt => opt.Ignore());

        CreateMap<BranchTable, BranchDto>();

        CreateMap<TransactionDto, TransactionTable>();
        CreateMap<TransactionTable, TransactionDto>();
    }
}