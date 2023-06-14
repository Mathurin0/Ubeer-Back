using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class Beer_DTO
	{
		public string ID { get; set; }

		public string IdStyle { get; set; }

		public string Libelle { get; set; }

		public float AlcoholVolume { get; set; }

		public float UnitPrice { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

		public string Image { get; set; }
	}
}
