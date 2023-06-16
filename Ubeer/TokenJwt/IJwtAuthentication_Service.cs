using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Ubeer.METIER.Metier;

namespace TokenJwt
{
	public interface IJwtAuthentication_Service
	{
		User_METIER Authenticate(string email, string password);

		string GenerateToken(string token, List<Claim> claims);

	}
}
