using Microsoft.Data.SqlClient;
using System.Net;
using Ubeer.DAL.DAL;
using System;
using System.Collections.Generic;
namespace Ubeer.DAL.Depot
{
    public class BeerStyleDepot_DAL : Depot_DAL<BeerStyle_DAL>
    {
        public override List<BeerStyle_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT ID, Libelle, Creation, LastUpdate FROM BeerStyle";
            var reader = commande.ExecuteReader();

            var styleList = new List<BeerStyle_DAL>();

            while (reader.Read())
            {
                var item = new BeerStyle_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetString(1),
										reader.GetDateTime(2),
										reader.GetDateTime(3)
										);

                styleList.Add(item);
            }

            DetruireConnexionEtCommande();

            return styleList;
        }

        public override BeerStyle_DAL GetByID(string ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, Libelle, Creation, LastUpdate FROM BeerStyle WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            BeerStyle_DAL style;
            if (reader.Read())
            {
                style = new BeerStyle_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetString(1),
										reader.GetDateTime(2),
										reader.GetDateTime(3)
										);
            }
            else
            {
                throw new Exception($"No occurrence of ID {ID} in beerStyle table");
            }

            DetruireConnexionEtCommande();

            return style;
        }

        public override BeerStyle_DAL Insert(BeerStyle_DAL style)
        {
            CreerConnexionEtCommande();

			//Création de l'ID
			string ID = "";
			while (ID == "")
			{
				Guid guid = Guid.NewGuid();
				ID = guid.ToString();
				commande.CommandText = $"SELECT COUNT(ID) FROM BeerStyle WHERE ID = '{ID}'";
				int isIdAlreadyUsed = Convert.ToInt32(commande.ExecuteNonQuery());

				if (isIdAlreadyUsed > 0)
				{
					ID = "";
				}
			}

			commande.CommandText = "INSERT INTO BeerStyle (ID, libelle, Creation, LastUpdate) VALUES (@ID, @Libelle, GETDATE(), GETDATE());";
            commande.Parameters.Add(new SqlParameter("@Libelle", style.Libelle));
			commande.Parameters.Add(new SqlParameter("@ID", ID));

            int nbLinesAffected = commande.ExecuteNonQuery();

            if (nbLinesAffected != 1) 
            {
                throw new Exception($"{nbLinesAffected} lignes affectées dans la table BeerStyle");
            }

			DetruireConnexionEtCommande();

            return style;
        }

        public override BeerStyle_DAL Update(BeerStyle_DAL style)
        {
            CreerConnexionEtCommande();

			commande.CommandText = "UPDATE BeerStyle SET libelle=@Libelle, LastUpdate=GETDATE() WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@Libelle", style.Libelle));
			commande.Parameters.Add(new SqlParameter("@ID", style.ID));

			var affectedRow = (int)commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to insert beerStyle ID : {style.ID}");
            }

            DetruireConnexionEtCommande();

            return style;
        }

        public override void Delete(BeerStyle_DAL style)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM BeerStyle WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", style.ID));
            var affectedRow = commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to delete beerStyle ID {style.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
