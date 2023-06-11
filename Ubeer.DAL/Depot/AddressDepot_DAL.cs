using Microsoft.Data.SqlClient;
using Ubeer.DAL.DAL;

namespace Ubeer.DAL.Depot
{
    public class AddressDepot_DAL : Depot_DAL<Address_DAL>
    {
        public override List<Address_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT ID, IdUser, Libelle, Address, AddressComplement, City, Region, Country, PostalCode, PhoneNumber FROM Address";
            var reader = commande.ExecuteReader();

            var addressList = new List<Address_DAL>();

            while (reader.Read())
            {
                var address = new Address_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(7),
                                        reader.GetString(8),
                                        reader.GetString(9),
                                        reader.GetString(10)
                                        );

                addressList.Add(address);
            }

            DetruireConnexionEtCommande();

            return addressList;
        }

        public override Address_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdUser, Libelle, Address, AddressComplement, City, Region, Country, PostalCode, PhoneNumber FROM address WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Address_DAL address;
            if (reader.Read())
            {
                address = new Address_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(7),
                                        reader.GetString(8),
                                        reader.GetString(9),
                                        reader.GetString(10)
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

            commande.CommandText = "INSERT INTO Address (libelle, address, addresscomplement, city, region, country, postalcode, phonenumber) VALUES (@Libelle, @Address, @AddressComplement, @City, @Region, @Country, @PostalCode, @PhoneNumber); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Libelle", address.Libelle));
            commande.Parameters.Add(new SqlParameter("@Address", address.Address));
            commande.Parameters.Add(new SqlParameter("@AddressComplement", address.AddressComplement));
            commande.Parameters.Add(new SqlParameter("@City", address.City));
            commande.Parameters.Add(new SqlParameter("@Region", address.Region));
            commande.Parameters.Add(new SqlParameter("@Country", address.Country));
            commande.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
            commande.Parameters.Add(new SqlParameter("@PhoneNumber", address.PhoneNumber));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            address.ID = ID;

            DetruireConnexionEtCommande();

            return address;
        }

        public override Address_DAL Update(Address_DAL address)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Address SET libelle=@Libelle, address=@Address, addresscomplement=@AddressCompelement, city=@City, region=@Region, country=@Country, phoneNumber=@phoneNumber WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@Libelle", address.Libelle));
            commande.Parameters.Add(new SqlParameter("@Address", address.Address));
            commande.Parameters.Add(new SqlParameter("@AddressComplement", address.AddressComplement));
            commande.Parameters.Add(new SqlParameter("@City", address.City));
            commande.Parameters.Add(new SqlParameter("@Region", address.Region));
            commande.Parameters.Add(new SqlParameter("@Country", address.Country));
            commande.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
            commande.Parameters.Add(new SqlParameter("@PhoneNumber", address.PhoneNumber)); ;

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
