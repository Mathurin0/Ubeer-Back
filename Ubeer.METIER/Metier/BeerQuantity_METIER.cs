using System;
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
        public string IdBeer { get; set; }

        public string IdCommand { get; set; }

        public int Quantity { get; set; }

		public DateTime LastUpdate { get; set; }

		public BeerQuantity_METIER(string idBeer, string idCommand, int quantity, DateTime lastUpdate) => (IdBeer, IdCommand, Quantity, LastUpdate) = (idBeer, idCommand, quantity, lastUpdate);

	}
}
