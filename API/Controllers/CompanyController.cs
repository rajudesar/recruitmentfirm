using API.Common;
using Application.Customers.CompanyModule.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ApiController
    {
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateCompany(CreateCompanyCommand model)
        {
            return Ok(await Mediator.Send(model));
        }
    }
}
