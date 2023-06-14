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
	public class Stock_Service
	{
		#region GetAll
		public List<Stock_METIER> GetAll()
		{
			var result = new List<Stock_METIER>();
			var depot = new StockDepot_DAL();
			foreach (var item in depot.GetAll())
			{
				result.Add(new Stock_METIER(item.IdBrewery, item.IdBeer, item.Quantity, item.LastUpdate));
			}
			return result;
		}

		#endregion

		#region GetByIdBeer
		public Stock_METIER GetByIdBeerAndIdBrewery(int idBeer, int IdBrewery)
		{
			var depot = new StockDepot_DAL();
			var stock = depot.GetByIdBeerAndIdBrewery(idBeer, IdBrewery);
			var result = new Stock_METIER(stock.IdBrewery, stock.IdBeer, stock.Quantity, stock.LastUpdate);
			return result;
		}
		#endregion

		#region GetByIdBeer
		public Stock_METIER GetByIdBeer(int idBeer)
		{
			var depot = new StockDepot_DAL();
			var stock = depot.GetByIdBeer(idBeer);
			var result = new Stock_METIER(stock.IdBrewery, stock.IdBeer, stock.Quantity, stock.LastUpdate);
			return result;
		}
		#endregion

		#region GetByIdService
		public List<Stock_METIER> GetByIdBrewery(int idAddress)
		{
			var result = new List<Stock_METIER>();
			var depot = new StockDepot_DAL();
			foreach (var item in depot.GetByIdBrewery(idAddress))
			{
				result.Add(new Stock_METIER(item.IdBrewery, item.IdBeer, item.Quantity, item.LastUpdate));
			}
			return result;
		}
		#endregion

		#region Insert
		public void Insert(Stock_DTO input)
		{
			var stock = new Stock_DAL(input.IdBrewery, input.IdBeer, input.Quantity, input.LastUpdate);
			var depot = new StockDepot_DAL();
			depot.Insert(stock);
		}
		#endregion

		#region Update
		public void Update(Stock_DTO input)
		{
			var stock = new Stock_DAL(input.IdBrewery, input.IdBeer, input.Quantity, input.LastUpdate);
			var depot = new StockDepot_DAL();
			depot.Update(stock);
		}
		#endregion

		#region Delete
		public void Delete(int id)
		{
			Stock_DAL stock;
			StockDepot_DAL depot = new();
			stock = depot.GetByID(id);
			depot.Delete(stock);
		}
		#endregion
	}
}
