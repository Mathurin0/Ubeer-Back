using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class Address_DTO
	{
		public string ID { get; set; }

		public string IdUser { get; set; }

		public string Libelle { get; set; }

		public string Address { get; set; }

		public string AddressComplement { get; set; }

		public string City { get; set; }

		public string Region { get; set; }

		public string Country { get; set; }

		public int PostalCode { get; set; }

		public string PhoneNumber { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }
	}
}
