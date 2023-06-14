using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DTO.DTO
{
	public class Command_DTO
	{
		public int ID { get; set; }

		public int IdUser { get; set; }

		public int IdAddress { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime EstimatedDeliveryDate { get; set; }

		public DateTime RealDeliveryDate { get; set; }

		public DateTime LastUpdate { get; set; }
	}
}
