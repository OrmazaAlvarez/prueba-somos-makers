using Domain.Loans;
using Master.Base.Loans;
using Shared;
using UseCase.Loans.Interface;

namespace UseCase.Loans.Query
{
    public class UseCaseGeAll : IUseCaseGetAll
    {

        private readonly ILoansRepository _loansRepository;

        public UseCaseGeAll(ILoansRepository loansRepository)
        {
            _loansRepository = loansRepository;
        }
        public IUseCaseGetAll Without(SqlServerContext sqlServerContext)
        {
            _loansRepository.UseContext(sqlServerContext);
            return this;
        }

        public IEnumerable<LoansDto> GetAll(long userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("UserId must be greater than zero.", nameof(userId));
            }
            return _loansRepository.GetLoans(userId).Select(l => new LoansDto() {
                Id = l.Id,
                UserId = l.UserId,
                Amount = l.Amount,
                TermMonths = l.TermMonths,
                Status = l.Status
            });
        }
    }
}
