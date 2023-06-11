using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class User_DAL
    {
        public int Id {  get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime MemberShipDate { get; set; }

        public User_DAL(int id, string userName, string password, string email, DateTime memberShipDate) => (Id, UserName, Password, Email, MemberShipDate) = (id, userName, password, email, memberShipDate);

        public User_DAL(string userName, string password, string email, DateTime memberShipDate) => (UserName, Password, Email, MemberShipDate) = (userName, password, email, memberShipDate);

    }
}
