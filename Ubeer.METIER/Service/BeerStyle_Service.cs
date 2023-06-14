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
	public class BeerStyle_Service
	{
		private readonly BeerStyleDepot_DAL depot = new BeerStyleDepot_DAL();

		#region GetAll
		public List<BeerStyle_METIER> GetAll()
		{
			var result = new List<BeerStyle_METIER>();
			foreach (var item in depot.GetAll())
			{
				result.Add(new BeerStyle_METIER(item.ID, item.Libelle, item.Creation, item.LastUpdate));
			}
			return result;
		}

		#endregion
		#region GetByID
		public BeerStyle_METIER GetByID(string id)
		{
			var beerStyle = depot.GetByID(id);
			return new BeerStyle_METIER(beerStyle.ID, beerStyle.Libelle, beerStyle.Creation, beerStyle.LastUpdate);
		}
		#endregion

		#region Insert
		public void Insert(BeerStyle_DTO input)
		{
			var beerStyle = new BeerStyle_DAL(input.Libelle, input.Creation, input.LastUpdate);
			depot.Insert(beerStyle);
		}
		#endregion

		#region Update
		public void Update(BeerStyle_DTO input)
		{
			var beerStyle = new BeerStyle_DAL(input.ID, input.Libelle, input.Creation, input.LastUpdate);
			depot.Update(beerStyle);
		}
		#endregion

		#region Delete
		public void Delete(string id)
		{
			BeerStyle_DAL beerStyle;
			beerStyle = depot.GetByID(id);
			depot.Delete(beerStyle);
		}
		#endregion
	}
}
