using System;
using System.Collections.Generic;
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
	public class Beer_Service
	{
		#region GetAll
		public List<Beer_METIER> GetAll()
		{
			var result = new List<Beer_METIER>();
			var depot = new BeerDepot_DAL();
			foreach (var item in depot.GetAll())
			{
				result.Add(new Beer_METIER(item.ID, item.IdStyle, item.Libelle, item.AlcoholVolume, item.UnitPrice, item.Creation, item.LastUpdate, item.Image));
			}
			return result;
		}

		#endregion

		#region GetByID
		public Beer_METIER GetByID(string id)
		{
			var depot = new BeerDepot_DAL();
			var beer = depot.GetByID(id);
			return new Beer_METIER(beer.ID, beer.IdStyle, beer.Libelle, beer.AlcoholVolume, beer.UnitPrice, beer.Creation, beer.LastUpdate, beer.Image);
		}
		#endregion

		#region Insert
		public void Insert(Beer_DTO input)
		{
			var beer = new Beer_DAL(input.IdStyle, input.Libelle, input.AlcoholVolume, input.UnitPrice, input.Creation, input.LastUpdate, input.Image);
			var depot = new BeerDepot_DAL();
			depot.Insert(beer);
		}
		#endregion

		#region Update
		public void Update(Beer_DTO input)
		{
			var beer = new Beer_DAL(input.IdStyle, input.Libelle, input.AlcoholVolume, input.UnitPrice, input.Creation, input.LastUpdate, input.Image);
			var depot = new BeerDepot_DAL();
			depot.Update(beer);
		}
		#endregion

		#region Delete
		public void Delete(string id)
		{
			Beer_DAL beer;
			BeerDepot_DAL depot = new();
			beer = depot.GetByID(id);
			depot.Delete(beer);
		}
		#endregion
	}
}
