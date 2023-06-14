using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
    public class User_METIER
    {
        public string Id {  get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime MemberShipDate { get; set; }

		public DateTime LastUpdate { get; set; }

		public User_METIER(string id, string userName, string password, string email, DateTime memberShipDate, DateTime lastUpdate) => (Id, UserName, Password, Email, MemberShipDate, LastUpdate) = (id, userName, password, email, memberShipDate, lastUpdate);

		public User_METIER(string userName, string password, string email, DateTime memberShipDate, DateTime lastUpdate) => (UserName, Password, Email, MemberShipDate, LastUpdate) = (userName, password, email, memberShipDate, lastUpdate);

	}
}
