using Microsoft.Data.SqlClient;
using Ubeer.DAL.DAL;

namespace Ubeer.DAL.Depot
{
    public class UserDepot_DAL : Depot_DAL<User_DAL>
    {
        public override List<User_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT ID, UserName, Password, Email, MemberShipDate FROM User";
            var reader = commande.ExecuteReader();

            var userList = new List<User_DAL>();

            while (reader.Read())
            {
                var user = new User_DAL(reader.GetInt32(0),
                                  reader.GetString(1),
                                  reader.GetString(2),
                                  reader.GetString(3),
                                  reader.GetDateTime(4)
                                  );

                userList.Add(user);
            }

            DetruireConnexionEtCommande();

            return userList;
        }

        public override User_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, UserName, Password, Email, MemberShipDate FROM User WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            User_DAL user;
            if (reader.Read())
            {
                user = new User_DAL(reader.GetInt32(0),
                              reader.GetString(1),
                              reader.GetString(2),
                              reader.GetString(3),
                              reader.GetDateTime(4)
                              );
            }
            else
            {
                throw new Exception($"No occurrence of ID {ID} in User table");
            }

            DetruireConnexionEtCommande();

            return user;
        }

        public override User_DAL Insert(User_DAL user)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO User (username, password, email, membershipdate) VALUES (@UserName, @Password, @email, @MemberShipDate); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@UserName", user.UserName));
            commande.Parameters.Add(new SqlParameter("@Password", user.Password));
            commande.Parameters.Add(new SqlParameter("@Email", user.Email));
            commande.Parameters.Add(new SqlParameter("@MemberShipDate", DateTime.Now));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            user.Id = ID;

            DetruireConnexionEtCommande();

            return user;
        }

        public override User_DAL Update(User_DAL user)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE User SET username=@UserName, password=@password, email=@Email WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@UserName", user.UserName));
            commande.Parameters.Add(new SqlParameter("@Password", user.Password));
            commande.Parameters.Add(new SqlParameter("@Email", user.Email));

            var affectedRow = (int)commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to update user ID : {user.Id}");
            }

            DetruireConnexionEtCommande();

            return user;
        }

        public override void Delete(User_DAL user)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM User WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", user.Id));
            var affectedRow = commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to delete user ID {user.Id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
