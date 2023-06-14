using Microsoft.AspNetCore.Mvc;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Service;

namespace Ubeer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Brewery_Controller : Controller
	{
		private Brewery_Service service;

		public Brewery_Controller(Brewery_Service srv)
		{
			service = srv;
		}

		#region GetAll
		[HttpGet]
		public IEnumerable<Brewery_DTO> GetAll()
		{
			return service.GetAll().Select(item => new Brewery_DTO
			{
				ID = item.Id,
				Code = item.Code,
				Libelle = item.Libelle,
				PostalCode = item.PostalCode,
				City = item.City,
				WebsiteUrl = item.WebsiteUrl,
				Creation = item.Creation,
				LastUpdate = item.LastUpdate,
				Image = item.Image
			});
		}
		#endregion

		#region GetById
		[HttpGet("{id}")]
		public Brewery_DTO GetByID(int id)
		{
			var item = service.GetByID(id);
			return new Brewery_DTO()
			{
				ID = item.Id,
				Code = item.Code,
				Libelle = item.Libelle,
				PostalCode = item.PostalCode,
				City = item.City,
				WebsiteUrl = item.WebsiteUrl,
				Creation = item.Creation,
				LastUpdate = item.LastUpdate,
				Image = item.Image
			};
		}
		#endregion

		#region Insert
		[HttpPost]
		public void Insert([FromBody] Brewery_DTO item)
		{
			service.Insert(item);
		}
		#endregion

		#region Update
		[HttpPut]
		public void Update([FromBody] Brewery_DTO item)
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
