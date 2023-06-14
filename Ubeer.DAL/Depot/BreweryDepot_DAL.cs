using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;

namespace Ubeer.DAL.Depot
{
	public class BreweryDepot_DAL : Depot_DAL<Brewery_DAL>
	{
		public override List<Brewery_DAL> GetAll()
		{
			#region GetAll
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT ID, Code, Libelle, PostalCode, City, WebsiteUrl, Creation, LastUpdate, Image FROM Brewery";
			var reader = commande.ExecuteReader();

			var listeBreweries = new List<Brewery_DAL>();

			while (reader.Read())
			{
				var brewery = new Brewery_DAL(reader.GetGuid(0).ToString(),
											reader.GetString(1),
											reader.GetString(2),
											reader.GetInt32(3),
											reader.GetString(4),
											reader.GetString(5),
											reader.GetDateTime(6),
											reader.GetDateTime(7),
											reader.GetString(8));

				listeBreweries.Add(brewery);
			}

			DetruireConnexionEtCommande();

			return listeBreweries;
		}
		#endregion

		#region GetByID
		public override Brewery_DAL GetByID(string ID)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT ID, Code, Libelle, PostalCode, City, WebsiteUrl, Creation, LastUpdate, Image FROM Brewery WHERE ID = @ID";
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@ID", ID));
			var reader = commande.ExecuteReader();

			Brewery_DAL brewery;
			if (reader.Read())
			{
				brewery = new Brewery_DAL(reader.GetGuid(0).ToString(),
											reader.GetString(1),
											reader.GetString(2),
											reader.GetInt32(3),
											reader.GetString(4),
											reader.GetString(5),
											reader.GetDateTime(6),
											reader.GetDateTime(7),
											reader.GetString(8));
			}
			else
			{
				throw new Exception($"Aucune occurance de l'ID {ID} dans la table Brewery");
			}

			DetruireConnexionEtCommande();

			return brewery;
		}
		#endregion

		#region Insert
		public override Brewery_DAL Insert(Brewery_DAL brewery)
		{
			CreerConnexionEtCommande();

			//Création de l'ID
			string ID = "";
			while (ID == "")
			{
				Guid guid = Guid.NewGuid();
				ID = guid.ToString();
				commande.CommandText = $"SELECT COUNT(ID) FROM Brewery WHERE ID = '{ID}'";
				int isIdAlreadyUsed = Convert.ToInt32(commande.ExecuteNonQuery());

				if (isIdAlreadyUsed > 0)
				{
					ID = "";
				}
			}

			commande.CommandText = "INSERT INTO Brewery (ID, Code, Libelle, PostalCode, City, WebsiteUrl, Creation, LastUpdate, Image) VALUES (@ID, @Code, @Libelle, @PostalCode, @City, @WebsiteUrl, GETDATE(), GETDATE(), @Image); SELECT SCOPE_IDENTITY()";
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Code", brewery.Code));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Libelle", brewery.Libelle));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@PostalCode", brewery.PostalCode));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@City", brewery.City));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@WebsiteUrl", brewery.WebsiteUrl));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Image", brewery.Image));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@ID", ID));

			int nbLinesAffected = commande.ExecuteNonQuery();

			if (nbLinesAffected != 1)
			{
				throw new Exception($"{nbLinesAffected} lignes affectées dans la table Brewery");
			}

			DetruireConnexionEtCommande();

			return brewery;
		}
		#endregion

		#region Update
		public override Brewery_DAL Update(Brewery_DAL brewery)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "UPDATE Brewery SET ID=@ID, Code=@Code, Libelle=@Libelle, PostalCode=@PostalCode, City=@City, WebsiteUrl=@WebsiteUrl, LastUpdate=GETDATE(), Image=@Image WHERE ID=@ID";
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@ID", brewery.ID));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Code", brewery.Code));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Libelle", brewery.Libelle));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@PostalCode", brewery.PostalCode));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@City", brewery.City));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@WebsiteUrl", brewery.WebsiteUrl));
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Image", brewery.Image));

			var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

			if (nombreDeLignesAffectees != 1)
			{
				throw new Exception($"Impossible de mettre à jour l'Adherents d'ID : {brewery.ID}");
			}

			DetruireConnexionEtCommande();

			return brewery;
		}
		#endregion

		#region Delete
		public override void Delete(Brewery_DAL brewery)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "DELETE FROM Brewery WHERE ID=@ID";
			commande.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@ID", brewery.ID));
			var nombreDeLignesAffectees = commande.ExecuteNonQuery();

			if (nombreDeLignesAffectees != 1)
			{
				throw new Exception($"Impossible to delete the Brewery with ID : {brewery.ID}");
			}

			DetruireConnexionEtCommande();
		}
		#endregion
	}


}

