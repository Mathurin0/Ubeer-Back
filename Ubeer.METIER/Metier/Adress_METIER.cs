using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
	public class Adress_METIER
	{
		public int Id { get; set; }

		public int IdUser { get; set; }

		public string Libelle { get; set; }

		public string Address { get; set; }

		public string AddressComplement { get; set; }

		public string City { get; set; }

		public string Region { get; set; }

		public string Country { get; set; }

		public string PostalCode { get; set; }

		public string PhoneNumber { get; set; }

		public Adress_METIER(int id, int idUser, string libelle, string address, string addressComplement, string city, string region, string country, string postalCode, string phoneNumber) => (Id, IdUser, Libelle, Address, AddressComplement, City, Region, PostalCode, Country, PhoneNumber) = (id, idUser, libelle, address, addressComplement, city, region, postalCode, country, phoneNumber);

		public Adress_METIER(int idUser, string libelle, string address, string addressComplement, string city, string region, string country, string postalCode, string phoneNumber) => (IdUser, Libelle, Address, AddressComplement, City, Region, PostalCode, Country, PhoneNumber) = (idUser, libelle, address, addressComplement, city, region, postalCode, country, phoneNumber);
	}
}
