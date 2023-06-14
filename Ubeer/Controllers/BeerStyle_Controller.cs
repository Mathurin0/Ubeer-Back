using Microsoft.AspNetCore.Mvc;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Service;

namespace Ubeer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BeerStyle_Controller : Controller
	{
		private BeerStyle_Service service;

		public BeerStyle_Controller(BeerStyle_Service srv)
		{
			service = srv;
		}

		#region GetAll
		[HttpGet]
		public IEnumerable<BeerStyle_DTO> GetAll()
		{
			return service.GetAll().Select(item => new BeerStyle_DTO
			{
				ID = item.Id,
				Libelle = item.Libelle,
				Creation = item.Creation,
				LastUpdate = item.LastUpdate
			});
		}
		#endregion

		#region GetById
		[HttpGet("{id}")]
		public BeerStyle_DTO GetByID(int id)
		{
			var item = service.GetByID(id);
			return new BeerStyle_DTO()
			{
				ID = item.Id,
				Libelle = item.Libelle,
				Creation = item.Creation,
				LastUpdate = item.LastUpdate
			};
		}
		#endregion

		#region Insert
		[HttpPost]
		public void Insert([FromBody] BeerStyle_DTO item)
		{
			service.Insert(item);
		}
		#endregion

		#region Update
		[HttpPut]
		public void Update([FromBody] BeerStyle_DTO item)
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
