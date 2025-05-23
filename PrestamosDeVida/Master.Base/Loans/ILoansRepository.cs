using Master.Base.TableRows;
using Shared;

namespace Master.Base.Loans
{
    public interface ILoansRepository
    {
        void UseContext(SqlServerContext sqlServerContext);
        void Insert(long UserId, decimal Amount, int TermMonths);
        void Update(long Id, string status);
        IEnumerable<LoansTableRow> GetLoans(long userId);
    }
}
