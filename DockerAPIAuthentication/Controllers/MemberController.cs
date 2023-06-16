using DockerAPIDataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DockerAPIAuthentication.Controllers
{
    [Authorize]
    [Route("auth/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        public IConfiguration _configuration;

        public MemberController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return Ok();
        }
    }

}