using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TokenJwt;
using Ubeer.Models;

namespace Ubeer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class JwtToken_Controller : Controller
	{
		private IJwtAuthentication_Service _JwtAuthentication_Service;
		private IConfiguration _Config;

		public JwtToken_Controller(IJwtAuthentication_Service jwtAuthentication_Service, IConfiguration config)
		{
			_JwtAuthentication_Service = jwtAuthentication_Service;
			_Config = config;
		}

		[HttpPost]
		public IActionResult Login([FromBody] LoginModel model)
		{
			var user = _JwtAuthentication_Service.Authenticate(model.Email, model.Password);
			if (user != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Email, user.Email)
				};
				var token = _JwtAuthentication_Service.GenerateToken(_Config["Jwt:Key"], claims);
				return Ok(token);
			}
			return Unauthorized();
		}
	}
}
