namespace Domain.Loans
{
    public class LoansDto
    {
        public int Id  { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public string Status { get; set; } 
        public DateTime DateRequest { get; set; }
    }
}
