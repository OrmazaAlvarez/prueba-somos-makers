using Master.Base.Loans;
using Shared;
using System.Runtime.InteropServices;
using UseCase.Loans.Dtos;
using UseCase.Loans.Interface;

namespace UseCase.Loans.Comands
{
    public class UseCaseInsertLoans: IUseCaseInsertLoans
    {
        private readonly ILoansRepository _loansRepository;

        public UseCaseInsertLoans(ILoansRepository loansRepository)
        {
            _loansRepository = loansRepository;
        }
        public IUseCaseInsertLoans Without(SqlServerContext sqlServerContext) 
        {
            _loansRepository.UseContext(sqlServerContext);
            return this;
        }

        public string Insert(LoansInsertDto loansInsertDto)
        {
            ValidateLoansInsertDto(loansInsertDto);
            _loansRepository.Insert(loansInsertDto.UserId, loansInsertDto.Amount, loansInsertDto.TermMonths);
            return "Insert operation completed successfully.";
        }
        private void ValidateLoansInsertDto(LoansInsertDto loansInsertDto)
        {
            if (loansInsertDto == null)
                throw new ArgumentNullException(nameof(loansInsertDto), "Loan data must not be null.");

            if (loansInsertDto.UserId <= 0)
                throw new ArgumentException("UserId must be greater than zero.", nameof(loansInsertDto.UserId));

            if (loansInsertDto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.", nameof(loansInsertDto.Amount));

            if (loansInsertDto.TermMonths <= 0)
                throw new ArgumentException("TermMonths must be greater than zero.", nameof(loansInsertDto.TermMonths));
        }

    }
}
