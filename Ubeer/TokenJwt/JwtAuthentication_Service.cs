using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Ubeer.DAL.Depot;
using Ubeer.METIER.Metier;

namespace TokenJwt
{
	public class JwtAuthentication_Service : IJwtAuthentication_Service
	{
		public User_METIER Authenticate(string email, string password)
		{
			var depot = new UserDepot_DAL();
			var user = depot.Authenticate(email, password);

			return new User_METIER(user.Id, user.Password, user.Email, user.MemberShipDate, user.LastUpdate);
		}

		public string GenerateToken(string secret, List<Claim> claims)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
			var descriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(30),
				SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(descriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
