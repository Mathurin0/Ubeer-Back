﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class BeerQuantity_DTO
	{
		public string IdBeer { get; set; }

		public string IdCommand { get; set; }

		public int Quantity { get; set; }

		public DateTime LastUpdate { get; set; }
	}
}
