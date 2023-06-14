using Microsoft.AspNetCore.Mvc;
using Ubeer.DTO.DTO;
using Ubeer.METIER.Service;

namespace Ubeer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Command_Controller : ControllerBase
	{
		private Command_Service service;

		public Command_Controller(Command_Service srv)
		{
			service = srv;
		}

		#region GetAll
		[HttpGet]
		public IEnumerable<Command_DTO> GetAll()
		{
			return service.GetAll().Select(item => new Command_DTO
			{
				ID = item.Id,
				IdUser = item.IdUser,
				IdAddress = item.IdAddress,
				OrderDate = item.OrderDate,
				EstimatedDeliveryDate = item.EstimatedDeliveryDate,
				RealDeliveryDate = item.RealDeliveryDate,
				LastUpdate = item.LastUpdate
			});
		}
		#endregion

		#region GetByIdUser
		//[HttpGet("{idUser}")]			TODO
		//public List<Command_DTO> GetByIdUser(int idUser)
		//{
		//	return service.GetByIdUser(idUser).Select(item => new Command_DTO
		//	{
		//		ID = item.Id,
		//		IdUser = item.IdUser,
		//		IdAddress = item.IdAddress,
		//		OrderDate = item.OrderDate,
		//		EstimatedDeliveryDate = item.EstimatedDeliveryDate,
		//		RealDeliveryDate = item.RealDeliveryDate,
		//		LastUpdate = item.LastUpdate
		//	});
		//}
		#endregion

		#region GetByIdAddress
		//[HttpGet("{idAddress}")]		TODO
		//public List<Command_DTO> GetByIdAddress(int idAddress)
		//{
		//	return service.GetByIdAddress(idAddress).Select(item => new Command_DTO
		//	{
		//		ID = item.Id,
		//		IdUser = item.IdUser,
		//		IdAddress = item.IdAddress,
		//		OrderDate = item.OrderDate,
		//		EstimatedDeliveryDate = item.EstimatedDeliveryDate,
		//		RealDeliveryDate = item.RealDeliveryDate,
		//		LastUpdate = item.LastUpdate
		//	});
		//}
		#endregion

		#region Insert
		[HttpPost]
		public void Insert([FromBody] Command_DTO item)
		{
			service.Insert(item);
		}
		#endregion

		#region Update
		[HttpPut]
		public void Update([FromBody] Command_DTO item)
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
