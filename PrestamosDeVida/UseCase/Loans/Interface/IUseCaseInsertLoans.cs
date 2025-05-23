using Shared;
using UseCase.Loans.Dtos;

namespace UseCase.Loans.Interface
{
    public interface IUseCaseInsertLoans
    {
        IUseCaseInsertLoans Without(SqlServerContext sqlServerContext);
        string Insert(LoansInsertDto loansInsertDto);
    }
}
