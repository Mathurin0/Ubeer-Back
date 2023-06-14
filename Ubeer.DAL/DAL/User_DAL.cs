using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class User_DAL
    {
        public string Id {  get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime MemberShipDate { get; set; }

		public DateTime LastUpdate { get; set; }

		public User_DAL(string id, string userName, string password, string email, DateTime memberShipDate, DateTime lastUpdate) => (Id, UserName, Password, Email, MemberShipDate, LastUpdate) = (id, userName, password, email, memberShipDate, lastUpdate);

        public User_DAL(string userName, string password, string email, DateTime memberShipDate, DateTime lastUpdate) => (UserName, Password, Email, MemberShipDate, LastUpdate) = (userName, password, email, memberShipDate, lastUpdate);

    }
}
