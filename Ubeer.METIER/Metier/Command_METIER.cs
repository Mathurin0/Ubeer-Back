using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
    public class Command_METIER
    {
        public string Id { get; set; }

        public string IdUser { get; set; }

        public string IdAddress { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public DateTime RealDeliveryDate { get; set; }

		public DateTime LastUpdate { get; set; }

		public Command_METIER(string id, string idUser, string idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate, DateTime lastUpdate) => (Id, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate) = (id, idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate, lastUpdate);

		public Command_METIER(string idUser, string idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate, DateTime lastUpdate) => (IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate) = (idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate, lastUpdate);
	}
}
