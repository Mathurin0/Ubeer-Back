using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class Stock_DAL
    {
        public int IdBrewery { get; set; }

        public int IdBeer { get; set; }

        public int Quantity { get; set; }

		public DateTime LastUpdate { get; set; }

		public Stock_DAL(int idBrewery, int idBeer, int quantity, DateTime lastUpdate) => (IdBrewery, IdBeer, Quantity, LastUpdate) = (idBrewery, idBeer, quantity, lastUpdate);

		public Stock_DAL(int quantity, DateTime lastUpdate) => (Quantity, LastUpdate) = (quantity, lastUpdate);
	}
}
