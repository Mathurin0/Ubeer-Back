using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

			commande.CommandText = "SELECT ID, Code, Libelle, PostalCode, City, WebsiteUrl FROM Brewery";
			var reader = commande.ExecuteReader();

			var listeBreweries = new List<Brewery_DAL>();

			while (reader.Read())
			{
				var brewery = new Brewery_DAL(reader.GetInt32(0),
											reader.GetString(1),
											reader.GetString(2),
											reader.GetString(3),
											reader.GetString(4),
											reader.GetString(5));

				listeBreweries.Add(brewery);
			}

			DetruireConnexionEtCommande();

			return listeBreweries;
		}
		#endregion

		#region GetByID
		public override Brewery_DAL GetByID(int ID)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT ID, Code, Libelle, PostalCode, City, WebsiteUrl FROM Brewery WHERE ID = @ID";
			commande.Parameters.Add(new SqlParameter("@ID", ID));
			var reader = commande.ExecuteReader();

			Brewery_DAL brewery;
			if (reader.Read())
			{
				brewery = new Brewery_DAL(reader.GetInt32(0),
											reader.GetString(1),
											reader.GetString(2),
											reader.GetString(3),
											reader.GetString(4),
											reader.GetString(5));
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

			commande.CommandText = "INSERT INTO Brewery (Code, Libelle, PostalCode, City, WebsiteUrl) VALUES (@Code, @Libelle, @PostalCode, @City, @WebsiteUrl); SELECT SCOPE_IDENTITY()";
			commande.Parameters.Add(new SqlParameter("@Code", brewery.Code));
			commande.Parameters.Add(new SqlParameter("@Libelle", brewery.Libelle));
			commande.Parameters.Add(new SqlParameter("@PostalCode", brewery.PostalCode));
			commande.Parameters.Add(new SqlParameter("@City", brewery.City));
			commande.Parameters.Add(new SqlParameter("@WebsiteUrl", brewery.WebsiteUrl));

			var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

			brewery.ID = ID;

			DetruireConnexionEtCommande();

			return brewery;
		}
		#endregion

		#region Update
		public override Brewery_DAL Update(Brewery_DAL brewery)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "UPDATE Brewery SET ID=@ID, Code=@Code, Libelle=@Libelle, PostalCode=@PostalCode, City=@City, WebsiteUrl=@WebsiteUrl WHERE ID=@ID";
			commande.Parameters.Add(new SqlParameter("@ID", brewery.Id));
			commande.Parameters.Add(new SqlParameter("@Code", brewery.Code));
			commande.Parameters.Add(new SqlParameter("@Libelle", brewery.Libelle));
			commande.Parameters.Add(new SqlParameter("@PostalCode", brewery.PostalCode));
			commande.Parameters.Add(new SqlParameter("@City", brewery.City));
			commande.Parameters.Add(new SqlParameter("@WebsiteUrl", brewery.WebsiteUrl));

			var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

			if (nombreDeLignesAffectees != 1)
			{
				throw new Exception($"Impossible de mettre à jour l'Adherents d'ID : {brewery.Id}");
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
			commande.Parameters.Add(new SqlParameter("@ID", brewery.Id));
			var nombreDeLignesAffectees = commande.ExecuteNonQuery();

			if (nombreDeLignesAffectees != 1)
			{
				throw new Exception($"Impossible to delete the Brewery with ID : {brewery.Id}");
			}

			DetruireConnexionEtCommande();
		}
		#endregion
	}


}

