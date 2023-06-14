using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ubeer.DAL.DAL;

namespace Ubeer.DAL.Depot
{
    public class BeerDepot_DAL : Depot_DAL<Beer_DAL>
    {
        public override List<Beer_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT ID, IdStyle, Libelle, AlcoholVolume, UnitPrice, Creation, LastUpdate, Image FROM Beer";
            var reader = commande.ExecuteReader();

            var beerList = new List<Beer_DAL>();

            while (reader.Read())
            {
                var item = new Beer_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetString(2),
                                        (float)reader.GetDouble(3),
										(float)reader.GetDouble(4),
										reader.GetDateTime(5),
										reader.GetDateTime(6),
                                        reader.GetString(7)
										);

                beerList.Add(item);
            }

            DetruireConnexionEtCommande();

            return beerList;
        }

        public override Beer_DAL GetByID(string ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdStyle, Libelle, AlcoholVolume, UnitPrice, Creation, LastUpdate, Image FROM Beer WHERE ID=@ID";
            commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Beer_DAL beer;
            if (reader.Read())
            {
                beer = new Beer_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetString(2),
										(float)reader.GetDouble(3),
										(float)reader.GetDouble(4),
										reader.GetDateTime(5),
										reader.GetDateTime(6),
										reader.GetString(7)
										);
            }
            else
            {
                throw new Exception($"No occurrence of ID {ID} in beer table");
            }

            DetruireConnexionEtCommande();

            return beer;
        }

        public override Beer_DAL Insert(Beer_DAL beer)
        {
            CreerConnexionEtCommande();

			//Création de l'ID
			string ID = "";
			while (ID == "")
			{
				Guid guid = Guid.NewGuid();
				ID = guid.ToString();
				commande.CommandText = $"SELECT COUNT(ID) FROM Beer WHERE ID = '{ID}'";
				int isIdAlreadyUsed = Convert.ToInt32(commande.ExecuteNonQuery());

				if (isIdAlreadyUsed > 0)
				{
					ID = "";
				}
			}

			commande.CommandText = "INSERT INTO Beer (ID, IdStyle, libelle, alcoholvolume, unitprice, Creation, LastUpdate, Image) VALUES (@ID, @IdStyle, @Libelle, @AlcoholVolume, @UnitPrice, GETDATE(), GETDATE(), @Image) SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Libelle", beer.Libelle));
            commande.Parameters.Add(new SqlParameter("@AlcoholVolume", beer.AlcoholVolume));
            commande.Parameters.Add(new SqlParameter("@UnitPrice", beer.UnitPrice));
			commande.Parameters.Add(new SqlParameter("@Image", beer.Image));
			commande.Parameters.Add(new SqlParameter("@IdStyle", beer.IdStyle));
			commande.Parameters.Add(new SqlParameter("@ID", ID));

			int nbLinesAffected = commande.ExecuteNonQuery();

			if (nbLinesAffected != 1)
			{
				throw new Exception($"{nbLinesAffected} lignes affectées dans la table Beer");
			}

			DetruireConnexionEtCommande();

            return beer;
        }

        public override Beer_DAL Update(Beer_DAL beer)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Beer SET libelle=@Libelle, alcoholvolume=@AlcoholVolume, unitprice=@UnitPrice, LastUpdate=GETDATE(), Image=@Image WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@Libelle", beer.Libelle));
            commande.Parameters.Add(new SqlParameter("@AlcoholVolume", beer.AlcoholVolume));
            commande.Parameters.Add(new SqlParameter("@UnitPrice", beer.UnitPrice));
			commande.Parameters.Add(new SqlParameter("@Image", beer.Image));
			commande.Parameters.Add(new SqlParameter("@ID", beer.ID));

			var affectedRow = (int)commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to update beer ID : {beer.ID}");
            }

            DetruireConnexionEtCommande();

            return beer;
        }

        public override void Delete(Beer_DAL beer)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM Beer WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", beer.ID));
            var affectedRow = commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to delete beer ID {beer.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
