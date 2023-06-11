using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.METIER.Metier
{
    public class BeerStyle_METIER
	{
        public int Id { get; set; }

        public string Libelle { get; set; }

        public BeerStyle_METIER(int id, string libelle ) => (Id, Libelle ) = (id, libelle);
        public BeerStyle_METIER(string libelle) => (Libelle) = (libelle);

    }
}
