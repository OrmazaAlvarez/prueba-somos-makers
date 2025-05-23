using Domain.Loans;
using Shared;

namespace UseCase.Loans.Interface
{
    public interface IUseCaseGetAll
    {
        IUseCaseGetAll Without(SqlServerContext sqlServerContext);
        IEnumerable<LoansDto> GetAll(long userId);
    }
}
