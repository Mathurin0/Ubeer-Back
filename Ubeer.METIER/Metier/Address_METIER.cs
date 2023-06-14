using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
	public class Address_METIER
	{
		public int ID { get; set; }

		public int IdUser { get; set; }

		public string Libelle { get; set; }

		public string Address { get; set; }

		public string AddressComplement { get; set; }

		public string City { get; set; }

		public string Region { get; set; }

		public string Country { get; set; }

		public string PostalCode { get; set; }

		public string PhoneNumber { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

		public Address_METIER(int id, int idUser, string libelle, string address, string addressComplement, string city, string region, string country, string postalCode, string phoneNumber, DateTime creation, DateTime lastUpdate) => (ID, IdUser, Libelle, Address, AddressComplement, City, Region, PostalCode, Country, PhoneNumber, Creation, LastUpdate) = (id, idUser, libelle, address, addressComplement, city, region, postalCode, country, phoneNumber, creation, lastUpdate);

		public Address_METIER(int idUser, string libelle, string address, string addressComplement, string city, string region, string country, string postalCode, string phoneNumber, DateTime creation, DateTime lastUpdate) => (IdUser, Libelle, Address, AddressComplement, City, Region, PostalCode, Country, PhoneNumber, Creation, LastUpdate) = (idUser, libelle, address, addressComplement, city, region, postalCode, country, phoneNumber, creation, lastUpdate);
	}
}
