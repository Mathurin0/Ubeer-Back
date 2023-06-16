using Microsoft.Data.SqlClient;
using Ubeer.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Ubeer.DAL.Depot
{
    public class UserDepot_DAL : Depot_DAL<User_DAL>
    {
        public override List<User_DAL> GetAll()
        {
			CreerConnexionEtCommande();
            commande.CommandText = "SELECT ID, UserName, Password, Email, MemberShipDate, LastUpdate FROM [User]";
            var reader = commande.ExecuteReader();

            var userList = new List<User_DAL>();

            while (reader.Read())
            {
                var user = new User_DAL(reader.GetGuid(0).ToString(),
                                  reader.GetString(1),
                                  reader.GetString(2),
                                  reader.GetString(3),
                                  reader.GetDateTime(4),
                                  reader.GetDateTime(5)
                                  );

                userList.Add(user);
            }

            DetruireConnexionEtCommande();

            return userList;
        }

        public override User_DAL GetByID(string ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, UserName, Password, Email, MemberShipDate, LastUpdate FROM [User] WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            User_DAL user;
            if (reader.Read())
            {
                user = new User_DAL(reader.GetGuid(0).ToString(),
                              reader.GetString(1),
                              reader.GetString(2),
                              reader.GetString(3),
                              reader.GetDateTime(4),
                              reader.GetDateTime(5)
                              );
            }
            else
            {
                throw new Exception($"No occurrence of ID {ID} in [User] table");
            }

            DetruireConnexionEtCommande();

            return user;
        }

        public User_DAL Authenticate(string email, string password)
		{
			CreerConnexionEtCommande();

			var pwd = Encoding.ASCII.GetBytes(password);
			var sha = SHA1.Create();
			var hashList = sha.ComputeHash(pwd);
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < hashList.Length; i++)
			{
				builder.Append(hashList[i].ToString("x2"));
			}
			var hashedPassword = builder.ToString();

			commande.CommandText = "SELECT ID, UserName, Password, Email, MemberShipDate, LastUpdate FROM [User] WHERE Email=@Email AND Password=@Password";
			commande.Parameters.Add(new SqlParameter("@Email", email));
			commande.Parameters.Add(new SqlParameter("@Password", hashedPassword));
			var reader = commande.ExecuteReader();

			User_DAL user;
            if (reader.Read())
            {
                user = new User_DAL(reader.GetGuid(0).ToString(),
                              reader.GetString(1),
                              reader.GetString(2),
                              reader.GetString(3),
                              reader.GetDateTime(4),
                              reader.GetDateTime(5)
                              );
            }
            else
            {
                throw new Exception($"UserName or Password incorrect");
            }

			DetruireConnexionEtCommande();

            return user;
        }

        public override User_DAL Insert(User_DAL user)
        {
            CreerConnexionEtCommande();

			//Création de l'ID
			string ID = "";
			while (ID == "")
			{
				Guid guid = Guid.NewGuid();
				ID = guid.ToString();
				commande.CommandText = $"SELECT COUNT(ID) FROM [User] WHERE ID = '{ID}'";
				int isIdAlreadyUsed = Convert.ToInt32(commande.ExecuteNonQuery());

				if (isIdAlreadyUsed > 0)
				{
					ID = "";
				}
			}

			var pwd = Encoding.ASCII.GetBytes(user.Password);
			var sha = SHA1.Create();
			var hashList = sha.ComputeHash(pwd);
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < hashList.Length; i++)
			{
				builder.Append(hashList[i].ToString("x2"));
			}
			var hashedPassword = builder.ToString();

			commande.CommandText = "INSERT INTO [User] (ID, username, password, email, membershipdate, LastUpdate) VALUES (@ID, @UserName, @Password, @email, GETDATE(), GETDATE()); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@UserName", user.UserName));
            commande.Parameters.Add(new SqlParameter("@Password", hashedPassword));
            commande.Parameters.Add(new SqlParameter("@Email", user.Email));
			commande.Parameters.Add(new SqlParameter("@ID", ID));

			int nbLinesAffected = commande.ExecuteNonQuery();

			if (nbLinesAffected != 1)
			{
				throw new Exception($"{nbLinesAffected} lignes affectées dans la table BeerStyle");
			}

			DetruireConnexionEtCommande();

            return user;
        }

        public override User_DAL Update(User_DAL user)
        {
            CreerConnexionEtCommande();

            var hashedPassword = "";
            if (user.Password.Length < 500)
			{
				var pwd = Encoding.ASCII.GetBytes(user.Password);
				var sha = SHA1.Create();
				var hashList = sha.ComputeHash(pwd);
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < hashList.Length; i++)
				{
					builder.Append(hashList[i].ToString("x2"));
				}
				hashedPassword = builder.ToString();
			}

            commande.CommandText = "UPDATE [User] SET username=@UserName, password=@password, email=@Email, LastUpdate=GETDATE() WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@UserName", user.UserName));
            commande.Parameters.Add(new SqlParameter("@Password", hashedPassword));
            commande.Parameters.Add(new SqlParameter("@Email", user.Email));
			commande.Parameters.Add(new SqlParameter("@ID", user.Id));

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

            commande.CommandText = "DELETE FROM [User] WHERE ID=@ID";
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
