using Microsoft.AspNetCore.Mvc;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Service;

namespace Ubeer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Beer_Controller : ControllerBase
	{
		private Beer_Service service;

		public Beer_Controller(Beer_Service srv)
		{
			service = srv;
		}

		#region GetAll
		[HttpGet]
		public IEnumerable<Beer_DTO> GetAll()
		{
			return service.GetAll().Select(item => new Beer_DTO
			{
				ID = item.ID,
				IdStyle = item.IdStyle,
				Libelle = item.Libelle,
				AlcoholVolume = item.AlcoholVolume,
				UnitPrice = item.UnitPrice,
				Creation = item.Creation,
				LastUpdate = item.LastUpdate,
				Image = item.Image
			});
		}
		#endregion

		#region GetById
		[HttpGet("{id}")]
		public Beer_DTO GetByID(string id)
		{
			var item = service.GetByID(id);
			return new Beer_DTO()
			{
				ID = item.ID,
				IdStyle = item.IdStyle,
				Libelle = item.Libelle,
				AlcoholVolume = item.AlcoholVolume,
				UnitPrice = item.UnitPrice,
				Creation = item.Creation,
				LastUpdate = item.LastUpdate,
				Image = item.Image
			};
		}
		#endregion

		#region Insert
		[HttpPost]
		public void Insert([FromBody] Beer_DTO item)
		{
			service.Insert(item);
		}
		#endregion

		#region Update
		[HttpPut]
		public void Update([FromBody] Beer_DTO item)
		{
			service.Update(item);
		}
		#endregion

		#region Delete
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			service.Delete(id);
		}
		#endregion
	}
}
