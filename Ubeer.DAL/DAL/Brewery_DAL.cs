﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class Brewery_DAL
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Libelle { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string WebsiteUrl { get; set; }

        public Brewery_DAL(int id, string code, string libelle, string postalCode, string city, string websiteUrl ) => (ID, Code, Libelle, PostalCode, City, WebsiteUrl) = (id, code, libelle, postalCode, city, websiteUrl);

        public Brewery_DAL(string code, string libelle, string postalCode, string city, string websiteUrl) => (Code, Libelle, PostalCode, City, WebsiteUrl) = (code, libelle, postalCode, city, websiteUrl);

    }
}
