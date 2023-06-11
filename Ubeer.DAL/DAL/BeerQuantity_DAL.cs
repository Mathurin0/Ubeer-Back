using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class BeerQuantity_DAL
    {
        public int IdBeer { get; set; }

        public int IdCommand { get; set; }

        public int Quantity { get; set; }

        public BeerQuantity_DAL(int idBeer, int idCommand, int quantity ) => (IdBeer, IdCommand, Quantity) = ( idBeer, idCommand, quantity);

    }
}
