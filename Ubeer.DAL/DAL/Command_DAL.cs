using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class Command_DAL
    {
        public int ID { get; set; }

        public int IdUser { get; set; }

        public int IdAddress { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public DateTime RealDeliveryDate { get; set; }

		public DateTime LastUpdate { get; set; }

		public Command_DAL(int id, int idUser, int idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate, DateTime lastUpdate) => (ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate) = (id, idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate, lastUpdate);

        public Command_DAL(int idUser, int idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate, DateTime lastUpdate) => (IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate) = (idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate, lastUpdate);

    }
}
