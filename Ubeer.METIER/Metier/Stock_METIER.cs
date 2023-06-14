using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
    public class Stock_METIER
    {
        public int IdBrewery { get; set; }

        public int IdBeer { get; set; }
        public int Quantity { get; set; }

		public DateTime LastUpdate { get; set; }

		public Stock_METIER(int idBrewery, int idBeer, int quantity, DateTime lastUpdate) => (IdBrewery, IdBeer, Quantity, LastUpdate) = (idBrewery, idBeer, quantity, lastUpdate);

		public Stock_METIER(int quantity, DateTime lastUpdate) => (Quantity, LastUpdate) = (quantity, lastUpdate);

	}
}
