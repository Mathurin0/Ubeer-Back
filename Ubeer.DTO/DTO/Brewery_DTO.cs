using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class Brewery_DTO
	{
		public string ID { get; set; }

		public string Code { get; set; }

		public string Libelle { get; set; }

		public int PostalCode { get; set; }

		public string City { get; set; }

		public string WebsiteUrl { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

		public string Image { get; set; }
	}
}
