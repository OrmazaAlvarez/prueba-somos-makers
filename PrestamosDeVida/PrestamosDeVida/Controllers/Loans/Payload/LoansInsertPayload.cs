namespace PrestamosDeVida.Controllers.Loans.Payload
{
    public class LoansInsertPayload
    {
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }

    }
}
