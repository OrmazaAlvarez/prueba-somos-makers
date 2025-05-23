using Master.Base.Loans;
using Shared;
using UseCase.Loans.Dtos;
using UseCase.Loans.Interface;

namespace UseCase.Loans.Comands
{
    public class UseCaseUpdateLoans : IUseCaseUpdateLoans
    {
        private readonly ILoansRepository _loansRepository;

        public UseCaseUpdateLoans(ILoansRepository loansRepository)
        {
            _loansRepository = loansRepository;
        }

        public IUseCaseUpdateLoans Without(SqlServerContext sqlServerContext)
        {
            _loansRepository.UseContext(sqlServerContext);
            return this;
        }

        public string Update(LoansUpdateDto loansUpdateDto)
        {
            ValidateLoansUpdateDto(loansUpdateDto);
            _loansRepository.Update(loansUpdateDto.Id, loansUpdateDto.Status);
            return "Update operation completed successfully.";
        }

        private void ValidateLoansUpdateDto(LoansUpdateDto loansUpdateDto)
        {
            if (loansUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(loansUpdateDto), "LoansUpdateDto cannot be null.");
            }

            if (loansUpdateDto.Id <= 0)
            {
                throw new ArgumentException("Loan ID cannot be null or empty.", nameof(loansUpdateDto.Id));
            }

            if (string.IsNullOrWhiteSpace(loansUpdateDto.Status))
            {
                throw new ArgumentException("Loan status cannot be null or empty.", nameof(loansUpdateDto.Status));
            }
        }
    }
}
