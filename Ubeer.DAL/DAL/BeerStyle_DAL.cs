using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class BeerStyle_DAL
    {
        public int ID { get; set; }

        public string Libelle { get; set; }

        public BeerStyle_DAL(int id, string libelle ) => (ID, Libelle ) = (id, libelle);
        public BeerStyle_DAL(string libelle) => (Libelle) = (libelle);

    }
}
