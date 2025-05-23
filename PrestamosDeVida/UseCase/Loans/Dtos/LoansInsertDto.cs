namespace UseCase.Loans.Dtos
{
    public class LoansInsertDto
    {
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
    }
}
