using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Metier;

namespace Ubeer.METIER.Service
{
	public class Brewery_Service
	{
		#region GetAll
		public List<Brewery_METIER> GetAll()
		{
			var result = new List<Brewery_METIER>();
			var depot = new BreweryDepot_DAL();
			foreach (var item in depot.GetAll())
			{
				result.Add(new Brewery_METIER(item.ID, item.Code, item.Libelle, item.PostalCode, item.City, item.WebsiteUrl, item.Creation, item.LastUpdate, item.Image));
			}
			return result;
		}

		#endregion
		#region GetByID
		public Brewery_METIER GetByID(string id)
		{
			var depot = new BreweryDepot_DAL();
			var brewery = depot.GetByID(id);
			return new Brewery_METIER(brewery.ID, brewery.Code, brewery.Libelle, brewery.PostalCode, brewery.City, brewery.WebsiteUrl, brewery.Creation, brewery.LastUpdate, brewery.Image);
		}
		#endregion

		#region Insert
		public void Insert(Brewery_DTO input)
		{
			var brewery = new Brewery_DAL(input.ID, input.Code, input.Libelle, input.PostalCode, input.City, input.WebsiteUrl, input.Creation, input.LastUpdate, input.Image);
			var depot = new BreweryDepot_DAL();
			depot.Insert(brewery);
		}
		#endregion

		#region Update
		public void Update(Brewery_DTO input)
		{
			var brewery = new Brewery_DAL(input.ID, input.Code, input.Libelle, input.PostalCode, input.City, input.WebsiteUrl, input.Creation, input.LastUpdate, input.Image);
			var depot = new BreweryDepot_DAL();
			depot.Update(brewery);
		}
		#endregion

		#region Delete
		public void Delete(string id)
		{
			Brewery_DAL brewery;
			BreweryDepot_DAL depot = new();
			brewery = depot.GetByID(id);
			depot.Delete(brewery);
		}
		#endregion
	}
}
