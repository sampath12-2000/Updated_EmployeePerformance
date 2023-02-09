using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using EmployeePerformanceTracker1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace EmployeePerformanceTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorLoginController : Controller
    {
        private IConfiguration _configuration;
        private readonly EPTDBContext _context;
        public MentorLoginController(IConfiguration configuration, EPTDBContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        #region Login part
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            var mentor = Authenticate(login);
            if (mentor != null)
            {
                var token = Generate(mentor);
                var obj = new { Token = token };
                return Ok(obj);

            }
            return BadRequest();
        }
        #endregion

        #region authenticate part
        private Mentor Authenticate(Login mentorlogin)
        {
            var m1 = _context.Mentors.FirstOrDefault(
                m=>m.EmailId==mentorlogin.Email && m.Password==mentorlogin.Password && m.Role==mentorlogin.Role);
            if (m1 != null)
            {
                return m1;
            }
            return null;
        }
        #endregion

        #region Generate token
        private string Generate(Mentor mentor)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                new Claim(ClaimTypes.Email,mentor.EmailId),
                new Claim(ClaimTypes.NameIdentifier,mentor.Password),
                new Claim(ClaimTypes.NameIdentifier,mentor.MentorName),
                new Claim(ClaimTypes.Role,mentor.Role)
            };
            var token = new JwtSecurityToken(_configuration["JWT:Issuer"],
                                             _configuration["JWT:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(20),
                                             signingCredentials: credentials
                                             );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        #endregion
    }
}
