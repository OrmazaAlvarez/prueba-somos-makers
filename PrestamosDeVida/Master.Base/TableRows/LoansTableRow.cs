namespace Master.Base.TableRows
{
    public class LoansTableRow
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public string Status { get; set; }
        public DateTime DateRequest { get; set; }
    }
}
