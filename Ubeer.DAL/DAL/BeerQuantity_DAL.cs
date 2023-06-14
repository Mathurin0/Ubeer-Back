using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class BeerQuantity_DAL
    {
        public string IdBeer { get; set; }

        public string IdCommand { get; set; }

        public int Quantity { get; set; }

		public DateTime LastUpdate { get; set; }

		public BeerQuantity_DAL(string idBeer, string idCommand, int quantity, DateTime lastUpdate) => (IdBeer, IdCommand, Quantity, LastUpdate) = ( idBeer, idCommand, quantity, lastUpdate);
	}
}
