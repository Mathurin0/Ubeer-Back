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
		public Stock_DTO GetByIdBeerAndIdBrewery(string idBeer, string idBrewery)
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
		[Route("Beer/{idBeer}")]
		[HttpGet]
		public Stock_DTO GetByIdBeer(string idBeer)
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
		[Route("Brewery/{idBrewery}")]
		[HttpGet]
		public IEnumerable<Stock_DTO> GetByIdBrewery(string idBrewery)
		{
			return service.GetByIdBrewery(idBrewery).Select(item => new Stock_DTO
			{
				IdBrewery = item.IdBrewery,
				IdBeer = item.IdBeer,
				Quantity = item.Quantity,
				LastUpdate = item.LastUpdate
			});
		}
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
		[HttpDelete("{idBrewery},{idBeer}")]
		public void Delete(string idBrewery, string idBeer)
		{
			service.Delete(idBrewery, idBeer);
		}
		#endregion
	}
}
