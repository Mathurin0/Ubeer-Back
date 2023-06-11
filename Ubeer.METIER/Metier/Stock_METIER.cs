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

        public Stock_METIER(int idBrewery, int idBeer, int quantity) => (IdBrewery, IdBeer, Quantity) = (idBrewery, idBeer, quantity);

    }
}
