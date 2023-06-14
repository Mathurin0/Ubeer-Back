using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
    public class Brewery_METIER
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Libelle { get; set; }

        public int PostalCode { get; set; }

        public string City { get; set; }

        public string WebsiteUrl { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

		public string Image { get; set; }

		public Brewery_METIER(string id, string code, string libelle, int postalCode, string city, string websiteUrl, DateTime creation, DateTime lastUpdate, string image) => (Id, Code, Libelle, PostalCode, City, WebsiteUrl, Creation, LastUpdate, Image) = (id, code, libelle, postalCode, city, websiteUrl, creation, lastUpdate, image);

		public Brewery_METIER(string code, string libelle, int postalCode, string city, string websiteUrl, DateTime creation, DateTime lastUpdate, string image) => (Code, Libelle, PostalCode, City, WebsiteUrl, Creation, LastUpdate, Image) = (code, libelle, postalCode, city, websiteUrl, creation, lastUpdate, image);

	}
}
