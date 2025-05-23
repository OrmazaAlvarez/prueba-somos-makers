using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrestamosDeVida.Controllers.Loans.Payload;
using Shared;
using UseCase.Loans.Dtos;
using UseCase.Loans.Interface;

namespace PrestamosDeVida.Controllers.Loans
{
    [Route("api/loans")]
    public partial class LoansController : ControllerBase
    {
        [HttpPost]
        [Route("insert")]
        public IActionResult CreateLoan(
            [FromBody] LoansInsertPayload insertPayload,
            [FromServices] IUseCaseInsertLoans useCaseInsert,
            [FromServices] SqlServerContext sqlServerContext // Corrected usage
        )
        {
            // Fixed the incorrect usage of 'SqlServerContext' as a variable
            var result = useCaseInsert.Without(sqlServerContext).Insert(JsonConvert.DeserializeObject<LoansInsertDto>(JsonConvert.SerializeObject(insertPayload)));
            return Ok(result);
        }


        [HttpPut]
        [Route("update")]
        public IActionResult UpdateLoan(
            [FromBody] LoansUpdatePayload updatePayload,
            [FromServices] IUseCaseUpdateLoans useCaseUpdate,
            [FromServices] SqlServerContext sqlServerContext // Corrected usage
        )
        {
            // Fixed the incorrect usage of 'SqlServerContext' as a variable
            var result = useCaseUpdate.Without(sqlServerContext).Update(JsonConvert.DeserializeObject<LoansUpdateDto>(JsonConvert.SerializeObject(updatePayload)));
            return Ok(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetLoanById(
            [FromRoute] int id,
            [FromServices] IUseCaseGetAll useCaseGet,
            [FromServices] SqlServerContext sqlServerContext // Corrected usage
        )
        {
            // Fixed the incorrect usage of 'SqlServerContext' as a variable
            var loan = useCaseGet.Without(sqlServerContext).GetAll(id);
            if (loan == null)
            {
                return NotFound(new { message = "Loan not found" });
            }
            return Ok(loan);
        }
    }
}
