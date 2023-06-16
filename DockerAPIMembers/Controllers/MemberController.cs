using DockerAPIDataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DockerAPIMembers.Controllers
{
    [Authorize]
    [Route("member/member")]
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
            var tokenString = await HttpContext.GetTokenAsync("access_token");

            JwtSecurityToken JwtSecurityToken = new JwtSecurityToken(jwtEncodedString: tokenString);
            //string expiry = token.Claims.First(c => c.Type == "expiry").Value;
            
            Employee employee = new Employee();
            employee.SickLeaveHours = 1200;
            employee.BirthDate = DateTime.Now.AddDays(-12345);
            employee.EmployeeID = 12;
            employee.EmployeeName = "David Hasselhoff";

            return Ok(employee);
        }
    }

}