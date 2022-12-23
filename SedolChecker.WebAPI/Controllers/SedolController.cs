using Microsoft.AspNetCore.Mvc;
using SedolChecker.Domain.Services;
using System.Threading.Tasks;

namespace SedolChecker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedolController : ControllerBase
    {
        private readonly ISedolValidator _sedolValidator;

        public SedolController(ISedolValidator sedolValidator)
        {
            _sedolValidator = sedolValidator;
        }

        [HttpGet("{sedol}")]
        public async Task<IActionResult> Get(string sedol)
        {
            var response = await Task.Run(() => _sedolValidator.ValidateSedol(sedol));

            return Ok(response);
        }
    }
}
