using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class BeerStyle_DAL
    {
        public string ID { get; set; }

        public string Libelle { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

		public BeerStyle_DAL(string id, string libelle, DateTime creation, DateTime lastUpdate) => (ID, Libelle, Creation, LastUpdate) = (id, libelle, creation, lastUpdate);
        public BeerStyle_DAL(string libelle, DateTime creation, DateTime lastUpdate) => (Libelle, Creation, LastUpdate) = (libelle, creation, lastUpdate);

    }
}
