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
	public class BeerQuantity_Service
	{
		#region GetAll
		public List<BeerQuantity_METIER> GetAll()
		{
			var result = new List<BeerQuantity_METIER>();
			var depot = new BeerQuantityDepot_DAL();
			foreach (var item in depot.GetAll())
			{
				result.Add(new BeerQuantity_METIER(item.IdBeer, item.IdCommand, item.Quantity, item.LastUpdate));
			}
			return result;
		}

		#endregion

		#region GetByIdBeer
		public List<BeerQuantity_METIER> GetByIdBeer(string idBeer)
		{
			var result = new List<BeerQuantity_METIER>();
			var depot = new BeerQuantityDepot_DAL();
			var beerQuantity = depot.GetByIdBeer(idBeer);
			foreach (var item in beerQuantity)
			{
				result.Add(new BeerQuantity_METIER(item.IdBeer, item.IdCommand, item.Quantity, item.LastUpdate));
			}
			return result;
		}
		#endregion

		#region GetByIdService
		public List<BeerQuantity_METIER> GetByIdCommand(string idService)
		{
			var result = new List<BeerQuantity_METIER>();
			var depot = new BeerQuantityDepot_DAL();
			var beerQuantity = depot.GetByIdCommand(idService);
			foreach (var item in beerQuantity)
			{
				result.Add(new BeerQuantity_METIER(item.IdBeer, item.IdCommand, item.Quantity, item.LastUpdate));
			}
			return result;
		}
		#endregion

		#region Insert
		public void Insert(BeerQuantity_DTO input)
		{
			var beerQuantity = new BeerQuantity_DAL(input.IdBeer, input.IdCommand, input.Quantity, input.LastUpdate);
			var depot = new BeerQuantityDepot_DAL();
			depot.Insert(beerQuantity);
		}
		#endregion

		#region Delete
		public void Delete(string idBeer, string idCommand)
		{
			BeerQuantity_DAL beerQuantity;
			BeerQuantityDepot_DAL depot = new();
			beerQuantity = depot.GetByIdBeerAndIdCommande(idBeer, idCommand);
			depot.Delete(beerQuantity);
		}
		#endregion
	}
}
