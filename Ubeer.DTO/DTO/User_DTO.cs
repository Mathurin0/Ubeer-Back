using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class User_DTO
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public DateTime MemberShipDate { get; set; }

		public DateTime LastUpdate { get; set; }
	}
}
