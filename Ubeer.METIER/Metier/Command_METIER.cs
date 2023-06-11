﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Command_METIER(int id, int idUser, int idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate ) => (Id, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate) = (id, idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate);

        public Command_METIER(int idUser, int idAddress, DateTime orderDate, DateTime estimatedDeliveryDate, DateTime realDeliveryDate) => (IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate) = (idUser, idAddress, orderDate, estimatedDeliveryDate, realDeliveryDate);

    }
}
