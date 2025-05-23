using Master.Base.TableRows;
using Shared;
using System.Data.SqlClient;

namespace Master.Base.Loans
{
    public class LoansRepository: ILoansRepository
    {
        public SqlServerContext _sqlServerContext;
        public void UseContext(SqlServerContext sqlServerContext) 
        {
            _sqlServerContext = sqlServerContext;
        }
        public void Insert( long UserId, decimal Amount, int TermMonths)
        {
            string querey = "INSERT INTO Loans (UserId, Amount, TermMonths) VALUES (@UserId, @Amount, @TermMonths)";
            using (var connection = new SqlConnection(_sqlServerContext.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(querey, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@TermMonths", TermMonths);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(long Id, string status)
        {
            string querey = "UPDATE Loans SET Status = @Status WHERE Id = @Id";
            using (var connection = new SqlConnection(_sqlServerContext.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(querey, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Status", status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<LoansTableRow> GetLoans(long userId)
        {
            string conditions = string.Empty;

            if (userId > 0)
            {
                conditions = " WHERE UserId = @UserId";
            }

            string querey = $"SELECT * FROM Loans {conditions}";
            List<LoansTableRow> loans = new List<LoansTableRow>();
            using (var connection = new SqlConnection(_sqlServerContext.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(querey, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Process each loan record here
                            var loan = new LoansTableRow
                            {
                                Id = reader.GetInt32(0),
                                UserId = reader.GetInt32(1),
                                Amount = reader.GetDecimal(2),
                                TermMonths = reader.GetInt32(3),
                                Status = reader.GetString(4),
                                DateRequest = reader.GetDateTime(5)
                            };
                            // Do something with the loan object
                            loans.Add(loan);
                        }
                    }
                }
            }
            return loans.AsEnumerable();
        }
    }
}
