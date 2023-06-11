using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.METIER.Metier
{
    public class Brewery_METIER
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Libelle { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string WebsiteUrl { get; set; }

        public Brewery_METIER(int id, string code, string libelle, string postalCode, string city, string websiteUrl ) => (Id, Code, Libelle, PostalCode, City, WebsiteUrl) = (id, code, libelle, postalCode, city, websiteUrl);

        public Brewery_METIER(string code, string libelle, string postalCode, string city, string websiteUrl) => (Code, Libelle, PostalCode, City, WebsiteUrl) = (code, libelle, postalCode, city, websiteUrl);

    }
}
