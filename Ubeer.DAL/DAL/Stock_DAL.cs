﻿using System;
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

        public Stock_DAL(int idBrewery, int idBeer, int quantity) => (IdBrewery, IdBeer, Quantity) = (idBrewery, idBeer, quantity);

    }
}
