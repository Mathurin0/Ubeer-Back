using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Ubeer.DAL.DAL;

namespace Ubeer.DAL.Depot
{
    public class AddressDepot_DAL : Depot_DAL<Address_DAL>
    {
        public override List<Address_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT ID, IdUser, Libelle, Address, AddressComplement, City, Region, Country, PostalCode, PhoneNumber, Creation, LastUpdate FROM Address";
            var reader = commande.ExecuteReader();

            var addressList = new List<Address_DAL>();

            while (reader.Read())
            {
                var address = new Address_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6),
                                        reader.GetString(7),
                                        reader.GetInt32(8),
                                        reader.GetString(9),
                                        reader.GetDateTime(10),
                                        reader.GetDateTime(11));


				addressList.Add(address);
            }

            DetruireConnexionEtCommande();

            return addressList;
        }

        public override Address_DAL GetByID(string ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdUser, Libelle, Address, AddressComplement, City, Region, Country, PostalCode, PhoneNumber, Creation, LastUpdate FROM address WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Address_DAL address;
            if (reader.Read())
            {
                address = new Address_DAL(reader.GetGuid(0).ToString(),
										reader.GetGuid(1).ToString(),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6),
                                        reader.GetString(7),
                                        reader.GetInt32(8),
                                        reader.GetString(9),
										reader.GetDateTime(10),
										reader.GetDateTime(11)
										);
            }
            else
            {
                throw new Exception($"No occurrence of ID {ID} in address table");
            }

            DetruireConnexionEtCommande();

            return address;
        }

        public override Address_DAL Insert(Address_DAL address)
        {
            CreerConnexionEtCommande();

			//Création de l'ID
			string ID = "";
			while (ID == "")
			{
				Guid guid = Guid.NewGuid();
				ID = guid.ToString();
				commande.CommandText = $"SELECT COUNT(ID) FROM Address WHERE ID = '{ID}'";
				int isIdAlreadyUsed = Convert.ToInt32(commande.ExecuteNonQuery());

				if (isIdAlreadyUsed > 0)
				{
					ID = "";
				}
			}

			commande.CommandText = "INSERT INTO Address (ID, IdUser, Libelle, Address, AddressComplement, City, Region, Country, PostalCode, PhoneNumber, Creation, LastUpdate) VALUES (@ID, @IdUser, @Libelle, @Address, @AddressComplement, @City, @Region, @Country, @PostalCode, @PhoneNumber, GETDATE(), GETDATE()); SELECT SCOPE_IDENTITY()";
			commande.Parameters.Add(new SqlParameter("@IdUser", address.IdUser));
			commande.Parameters.Add(new SqlParameter("@Libelle", address.Libelle));
            commande.Parameters.Add(new SqlParameter("@Address", address.Address));
            commande.Parameters.Add(new SqlParameter("@AddressComplement", address.AddressComplement));
            commande.Parameters.Add(new SqlParameter("@City", address.City));
            commande.Parameters.Add(new SqlParameter("@Region", address.Region));
            commande.Parameters.Add(new SqlParameter("@Country", address.Country));
            commande.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
            commande.Parameters.Add(new SqlParameter("@PhoneNumber", address.PhoneNumber));
			commande.Parameters.Add(new SqlParameter("@ID", ID));

			var affectedRow = commande.ExecuteNonQuery();

			if (affectedRow != 1)
			{
				throw new Exception($"{affectedRow} lignes affectées dans la table Address");
			}

			address.ID = ID;

            DetruireConnexionEtCommande();

            return address;
        }

        public override Address_DAL Update(Address_DAL address)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Address SET Libelle=@Libelle, Address=@Address, AddressComplement=@AddressComplement, City=@City, Region=@Region, Country=@Country, PostalCode=@PostalCode, PhoneNumber=@phoneNumber, LastUpdate=GETDATE() WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@Libelle", address.Libelle));
            commande.Parameters.Add(new SqlParameter("@Address", address.Address));
            commande.Parameters.Add(new SqlParameter("@AddressComplement", address.AddressComplement));
            commande.Parameters.Add(new SqlParameter("@City", address.City));
            commande.Parameters.Add(new SqlParameter("@Region", address.Region));
            commande.Parameters.Add(new SqlParameter("@Country", address.Country));
            commande.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
            commande.Parameters.Add(new SqlParameter("@PhoneNumber", address.PhoneNumber)); ;
			commande.Parameters.Add(new SqlParameter("@ID", address.ID)); ;

			var affectedRow = (int)commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to update address ID : {address.ID}");
            }

            DetruireConnexionEtCommande();

            return address;
        }

        public override void Delete(Address_DAL address)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM address WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", address.ID));
            var affectedRow = commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to delete address ID {address.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
