using DockerAPIDataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using System.Text;
using Dapper;

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


            List<Employee> Employees = new List<Employee>();


            string constring = @"Server=localhost\SQLEXPRESS;Database=testdb;Trusted_Connection=True;";

            var sql = "select * from products";
            using (var connection = new SqlConnection(constring))
            {
                connection.Open();
                Employees = connection.Query<Employee>(sql).ToList();
            }



            return Ok(Employees);
        }
    }

}