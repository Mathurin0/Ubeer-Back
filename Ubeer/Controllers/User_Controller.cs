using Microsoft.AspNetCore.Mvc;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Service;

namespace Ubeer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class User_Controller : ControllerBase
	{
		private User_Service service;

		public User_Controller(User_Service srv)
		{
			service = srv;
		}

		#region GetAll
		[HttpGet]
		public IEnumerable<User_DTO> GetAll()
		{
			return service.GetAll().Select(item => new User_DTO
			{
				Id = item.Id,
				UserName = item.UserName,
				Password = item.Password,
				Email = item.Email,
				MemberShipDate = item.MemberShipDate,
				LastUpdate = item.LastUpdate
			});
		}
		#endregion

		#region GetById
		[HttpGet("{id}")]
		public User_DTO GetByID(string id)
		{
			var item = service.GetByID(id);
			return new User_DTO()
			{
				Id = item.Id,
				UserName = item.UserName,
				Password = item.Password,
				Email = item.Email,
				MemberShipDate = item.MemberShipDate,
				LastUpdate = item.LastUpdate
			};
		}
		#endregion

		#region Insert
		[HttpPost]
		public void Insert([FromBody] User_DTO item)
		{
			service.Insert(item);
		}
		#endregion

		#region Update
		[HttpPut]
		public void Update([FromBody] User_DTO item)
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
