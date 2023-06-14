using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class Beer_DTO
	{
		public int ID { get; set; }

		public int IdStyle { get; set; }

		public string Libelle { get; set; }

		public float AlcoholVolume { get; set; }

		public float UnitPrice { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

		public string Image { get; set; }
	}
}
