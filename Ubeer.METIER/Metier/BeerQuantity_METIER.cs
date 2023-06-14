﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
    public class BeerQuantity_METIER
    {
        public int IdBeer { get; set; }

        public int IdCommand { get; set; }

        public int Quantity { get; set; }

		public DateTime LastUpdate { get; set; }

		public BeerQuantity_METIER(int idBeer, int idCommand, int quantity, DateTime lastUpdate) => (IdBeer, IdCommand, Quantity, LastUpdate) = (idBeer, idCommand, quantity, lastUpdate);

	}
}
