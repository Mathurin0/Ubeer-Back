using Microsoft.AspNetCore.Mvc;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Service;

namespace Ubeer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Stock_Controller : ControllerBase
	{
		private Stock_Service service;

		public Stock_Controller(Stock_Service srv)
		{
			service = srv;
		}

		#region GetAll
		[HttpGet]
		public IEnumerable<Stock_DTO> GetAll()
		{
			return service.GetAll().Select(item => new Stock_DTO
			{
				IdBrewery = item.IdBrewery,
				IdBeer = item.IdBeer,
				Quantity = item.Quantity,
				LastUpdate = item.LastUpdate
			});
		}
		#endregion

		#region GetByIdBeerAndIdBrewery
		[HttpGet("{idBeer},{idBrewery}")]
		public Stock_DTO GetByIdBeerAndIdBrewery(int idBeer, int idBrewery)
		{
			var item = service.GetByIdBeerAndIdBrewery(idBeer, idBrewery);
			return new Stock_DTO()
			{
				IdBrewery = item.IdBrewery,
				IdBeer = item.IdBeer,
				Quantity = item.Quantity,
				LastUpdate = item.LastUpdate
			};
		}
		#endregion

		#region GetByIdBeer
		[HttpGet("{idBeer}")]
		public Stock_DTO GetByIdBeer(int idBeer)
		{
			var item = service.GetByIdBeer(idBeer);
			return new Stock_DTO()
			{
				IdBrewery = item.IdBrewery,
				IdBeer = item.IdBeer,
				Quantity = item.Quantity,
				LastUpdate = item.LastUpdate
			};
		}
		#endregion

		#region GetByIdBrewery
		//[HttpGet("{idBrewery}")]			TODO
		//public BeerQuantity_DTO GetByIdBrewery(int idBrewery)
		//{
		//	return service.GetByIdBrewery(idBrewery).Select(item => new Stock_DTO
		//	{
		//		IdBrewery = item.IdBrewery,
		//		IdBeer = item.IdBeer,
		//		Quantity = item.Quantity,
		//		LastUpdate = item.LastUpdate
		//	});
		//}
		#endregion

		#region Insert
		[HttpPost]
		public void Insert([FromBody] Stock_DTO item)
		{
			service.Insert(item);
		}
		#endregion

		#region Update
		[HttpPut]
		public void Update([FromBody] Stock_DTO item)
		{
			service.Update(item);
		}
		#endregion

		#region Delete
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			service.Delete(id);
		}
		#endregion
	}
}
