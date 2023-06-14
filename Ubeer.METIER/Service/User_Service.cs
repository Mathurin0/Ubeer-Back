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
	public class User_Service
	{
		#region GetAll
		public List<User_METIER> GetAll()
		{
			var result = new List<User_METIER>();
			var depot = new UserDepot_DAL();
			foreach (var item in depot.GetAll())
			{
				result.Add(new User_METIER(item.Id, item.UserName, item.Password, item.Email, item.MemberShipDate, item.LastUpdate));
			}
			return result;
		}

		#endregion
		#region GetByID
		public User_METIER GetByID(int id)
		{
			var depot = new UserDepot_DAL();
			var user = depot.GetByID(id);
			return new User_METIER(user.Id, user.UserName, user.Password, user.Email, user.MemberShipDate, user.LastUpdate);
		}
		#endregion

		#region Insert
		public void Insert(User_DTO input)
		{
			var user = new User_DAL(input.Id, input.UserName, input.Password, input.Email, input.MemberShipDate, input.LastUpdate);
			var depot = new UserDepot_DAL();
			depot.Insert(user);
		}
		#endregion

		#region Update
		public void Update(User_DTO input)
		{
			var user = new User_DAL(input.Id, input.UserName, input.Password, input.Email, input.MemberShipDate, input.LastUpdate);
			var depot = new UserDepot_DAL();
			depot.Update(user);
		}
		#endregion

		#region Delete
		public void Delete(int id)
		{
			User_DAL user;
			UserDepot_DAL depot = new();
			user = depot.GetByID(id);
			depot.Delete(user);
		}
		#endregion
	}
}
