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
	public class Command_Service
	{
		#region GetAll
		public List<Command_METIER> GetAll()
		{
			var result = new List<Command_METIER>();
			var depot = new CommandDepot_DAL();
			foreach (var item in depot.GetAll())
			{
				result.Add(new Command_METIER(item.ID, item.IdUser, item.IdAddress, item.OrderDate, item.EstimatedDeliveryDate, item.RealDeliveryDate, item.LastUpdate));
			}
			return result;
		}

		#endregion

		#region GetByID
		public Command_METIER GetByID(int id)
		{
			var depot = new CommandDepot_DAL();
			var command = depot.GetByID(id);
			return new Command_METIER(command.ID, command.IdUser, command.IdAddress, command.OrderDate, command.EstimatedDeliveryDate, command.RealDeliveryDate, command.LastUpdate);
		}
		#endregion

		#region GetByIdBeer
		public List<Command_METIER> GetByIdUser(int idUser)
		{
			var result = new List<Command_METIER>();
			var depot = new CommandDepot_DAL();
			var command = depot.GetByIdUser(idUser);
			foreach (var item in command)
			{
				result.Add(new Command_METIER(item.ID, item.IdUser, item.IdAddress, item.OrderDate, item.EstimatedDeliveryDate, item.RealDeliveryDate, item.LastUpdate));
			}
			return result;
		}
		#endregion

		#region GetByIdService
		public List<Command_METIER> GetByIdAddress(int idAddress)
		{
			var result = new List<Command_METIER>();
			var depot = new CommandDepot_DAL();
			var command = depot.GetByIdAddress(idAddress);
			foreach (var item in command)
			{
				result.Add(new Command_METIER(item.ID, item.IdUser, item.IdAddress, item.OrderDate, item.EstimatedDeliveryDate, item.RealDeliveryDate, item.LastUpdate));
			}
			return result;
		}
		#endregion

		#region Insert
		public void Insert(Command_DTO input)
		{
			var command = new Command_DAL(input.ID, input.IdUser, input.IdAddress, input.OrderDate, input.EstimatedDeliveryDate, input.RealDeliveryDate, input.LastUpdate);
			var depot = new CommandDepot_DAL();
			depot.Insert(command);
		}
		#endregion

		#region Update
		public void Update(Command_DTO input)
		{
			var command = new Command_DAL(input.ID, input.IdUser, input.IdAddress, input.OrderDate, input.EstimatedDeliveryDate, input.RealDeliveryDate, input.LastUpdate);
			var depot = new CommandDepot_DAL();
			depot.Update(command);
		}
		#endregion

		#region Delete
		public void Delete(int id)
		{
			Command_DAL command;
			CommandDepot_DAL depot = new();
			command = depot.GetByID(id);
			depot.Delete(command);
		}
		#endregion
	}
}
