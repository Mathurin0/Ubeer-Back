using Microsoft.AspNetCore.Mvc;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Service;

namespace Ubeer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BeerQuantity_Controller : ControllerBase
	{
		private BeerQuantity_Service service;

		public BeerQuantity_Controller(BeerQuantity_Service srv)
		{
			service = srv;
		}

		#region GetAll
		[HttpGet]
		public IEnumerable<BeerQuantity_DTO> GetAll()
		{
			return service.GetAll().Select(item => new BeerQuantity_DTO
			{
				IdBeer = item.IdBeer,
				IdCommand = item.IdCommand,
				Quantity = item.Quantity,
				LastUpdate = item.LastUpdate
			});
		}
		#endregion

		#region GetByIdCommand
		//[HttpGet("{idCommand}")]				TODO
		//public List<BeerQuantity_DTO> GetByIdCommand(int idCommand)
		//{
		//	return service.GetByIdCommand(idCommand).Select(item => new BeerQuantity_DTO
		//	{
		//		IdBeer = item.IdBeer,
		//		IdCommand = item.IdCommand,
		//		Quantity = item.Quantity,
		//		LastUpdate = item.LastUpdate
		//	});
		//}
		#endregion

		#region GetByIdBeer
		//[HttpGet("{idBeer}")]			TODO
		//public List<BeerQuantity_DTO> GetByIdBeer(int idBeer)
		//{
		//	return service.GetByIdBeer(idBeer).Select(item => new BeerQuantity_DTO
		//	{
		//		IdBeer = item.IdBeer,
		//		IdCommand = item.IdCommand,
		//		Quantity = item.Quantity,
		//		LastUpdate = item.LastUpdate
		//	});
		//}
		#endregion

		#region Insert
		[HttpPost]
		public void Insert([FromBody] BeerQuantity_DTO item)
		{
			service.Insert(item);
		}
		#endregion

		#region Update
		[HttpPut]
		public void Update([FromBody] BeerQuantity_DTO item)
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
