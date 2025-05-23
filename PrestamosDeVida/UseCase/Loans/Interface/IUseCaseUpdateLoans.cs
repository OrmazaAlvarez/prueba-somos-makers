
using Shared;
using UseCase.Loans.Dtos;

namespace UseCase.Loans.Interface
{
    public interface IUseCaseUpdateLoans
    {
        IUseCaseUpdateLoans Without(SqlServerContext sqlServerContext);
        string Update(LoansUpdateDto loansUpdateDto);
    }
}
