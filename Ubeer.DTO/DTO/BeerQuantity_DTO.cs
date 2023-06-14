using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class BeerQuantity_DTO
	{
		public int IdBeer { get; set; }

		public int IdCommand { get; set; }

		public int Quantity { get; set; }

		public DateTime LastUpdate { get; set; }
	}
}
