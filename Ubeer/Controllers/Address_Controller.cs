using Microsoft.AspNetCore.Mvc;
using Ubeer.METIER.Service;
using Ubeer.DTO.DTO;

namespace Ubeer.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Address_Controller : ControllerBase
	{
		private Address_Service service;

		public Address_Controller(Address_Service srv)
		{
			service = srv;
		}

		#region GetAll
		[HttpGet]
		public IEnumerable<Address_DTO> GetAll()
		{
			return service.GetAll().Select(item => new Address_DTO
			{
				ID = item.ID,
				IdUser = item.IdUser,
				Libelle = item.Libelle,
				Address = item.Address,
				AddressComplement = item.AddressComplement,
				City = item.City,
				Region = item.Region,
				Country = item.Country,
				PostalCode = item.PostalCode,
				PhoneNumber = item.PhoneNumber,
				Creation = item.Creation,
				LastUpdate = item.LastUpdate
			});
		}
		#endregion

		#region GetById
		[HttpGet("{id}")]
		public Address_DTO GetByID(string id)
		{
			var item = service.GetByID(id);
			return new Address_DTO()
			{
				ID = item.ID,
				IdUser = item.IdUser,
				Libelle = item.Libelle,
				Address = item.Address,
				AddressComplement = item.AddressComplement,
				City = item.City,
				Region = item.Region,
				Country = item.Country,
				PostalCode = item.PostalCode,
				PhoneNumber = item.PhoneNumber,
				Creation = item.Creation,
				LastUpdate = item.LastUpdate
			};
		}
		#endregion

		#region Insert
		[HttpPost]
		public void Insert([FromBody] Address_DTO item)
		{
			service.Insert(item);
		}
		#endregion

		#region Update
		[HttpPut]
		public void Update([FromBody] Address_DTO item)
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