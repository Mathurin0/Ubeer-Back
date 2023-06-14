using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
    public class BeerStyle_METIER
	{
        public int Id { get; set; }

        public string Libelle { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

		public BeerStyle_METIER(int id, string libelle, DateTime creation, DateTime lastUpdate) => (Id, Libelle, Creation, LastUpdate) = (id, libelle, creation, lastUpdate);
		public BeerStyle_METIER(string libelle, DateTime creation, DateTime lastUpdate) => (Libelle, Creation, LastUpdate) = (libelle, creation, lastUpdate);

	}
}
