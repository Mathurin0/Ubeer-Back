using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Metier;

namespace Ubeer.METIER.Service
{
	public class Address_Service
	{
		#region GetAll
		public List<Address_METIER> GetAll()
		{
			var result = new List<Address_METIER>();
			var depot = new AddressDepot_DAL();
			foreach (var item in depot.GetAll())
			{
				result.Add(new Address_METIER(item.ID, item.IdUser, item.Libelle, item.Address, item.AddressComplement, item.City, item.Region, item.PostalCode, item.Country, item.PhoneNumber, item.Creation, item.LastUpdate));
			}
			return result;
		}

		#endregion
		#region GetByID
		public Address_METIER GetByID(int id)
		{
			var depot = new AddressDepot_DAL();
			var address = depot.GetByID(id);
			return new Address_METIER(address.ID, address.IdUser, address.Libelle, address.Address, address.AddressComplement, address.City, address.Region, address.PostalCode, address.Country, address.PhoneNumber, address.Creation, address.LastUpdate);
		}
		#endregion

		#region Insert
		public void Insert(Address_DTO input)
		{
			var address = new Address_DAL(input.IdUser, input.Libelle, input.Address, input.AddressComplement, input.City, input.Region, input.PostalCode, input.Country, input.PhoneNumber, input.Creation, input.LastUpdate);
			var depot = new AddressDepot_DAL();
			depot.Insert(address);
		}
		#endregion

		#region Update
		public void Update(Address_DTO input)
		{
			var address = new Address_DAL(input.IdUser, input.Libelle, input.Address, input.AddressComplement, input.City, input.Region, input.PostalCode, input.Country, input.PhoneNumber, input.Creation, input.LastUpdate);
			var depot = new AddressDepot_DAL();
			depot.Update(address);
		}
		#endregion

		#region Delete
		public void Delete(int id)
		{
			Address_DAL address;
			AddressDepot_DAL depot = new();
			address = depot.GetByID(id);
			depot.Delete(address);
		}
		#endregion
	}
}
