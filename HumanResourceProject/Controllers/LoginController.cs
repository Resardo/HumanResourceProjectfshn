using Domain.Contracts;
using DTO.LoginDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ILoginDomain _loginDomain;

        public LoginController(IConfiguration config, ILoginDomain loginDomain)
        {
            _config = config;
            _loginDomain = loginDomain;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("loginAuthentication")]
        public IActionResult Authenticate([FromBody] LoginCredentialsDTO login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(login);
                }
                
               
                var users = _loginDomain.GetAllUsers(login);
                if (users != null)
                {
                    var token = Generate(users);
                    return Ok(token);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Authorize]
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserLoginById([FromRoute] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _loginDomain.GetUserById(userId);

                if (user != null)
                    return Ok(user);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string Generate(LoginDTO dto)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:secret"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,dto.Username),
                new Claim(ClaimTypes.Email,dto.Email),
                

            };

            var token = new JwtSecurityToken(_config["jwt:validissuer"],
                _config["jwt:validaudience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
