using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class Command_DTO
	{
		public string ID { get; set; }

		public string IdUser { get; set; }

		public string IdAddress { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime EstimatedDeliveryDate { get; set; }

		public DateTime RealDeliveryDate { get; set; }

		public DateTime LastUpdate { get; set; }
	}
}
