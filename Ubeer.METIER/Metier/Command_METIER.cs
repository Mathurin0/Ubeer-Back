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
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdAddress { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public DateTime RealDeliveryDate { get; set; }

		public DateTime LastUpdate { get; set; }

		public Command_METIER(int id, int idUser, int idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate, DateTime lastUpdate) => (Id, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate) = (id, idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate, lastUpdate);

		public Command_METIER(int idUser, int idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate, DateTime lastUpdate) => (IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate) = (idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate, lastUpdate);
	}
}
