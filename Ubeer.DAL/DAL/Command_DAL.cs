using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class Command_DAL
    {
        public string ID { get; set; }

        public string IdUser { get; set; }

        public string IdAddress { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public DateTime RealDeliveryDate { get; set; }

		public DateTime LastUpdate { get; set; }

		public Command_DAL(string id, string idUser, string idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate, DateTime lastUpdate) => (ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate) = (id, idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate, lastUpdate);

        public Command_DAL(string idUser, string idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate, DateTime lastUpdate) => (IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate) = (idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate, lastUpdate);

    }
}
