using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;

namespace Ubeer.DAL.Depot
{
	public class StockDepot_DAL : Depot_DAL<Stock_DAL>
	{
		#region GetAll
		public override List<Stock_DAL> GetAll()
		{
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT IdBrewery, IdBeer, Quantity, LastUpdate FROM Stock";
			var reader = commande.ExecuteReader();

			var listeStocks = new List<Stock_DAL>();

			while (reader.Read())
			{
				var stock = new Stock_DAL(reader.GetGuid(0).ToString(),
											reader.GetGuid(1).ToString(),
											reader.GetInt32(2),
											reader.GetDateTime(3));

				listeStocks.Add(stock);
			}

			DetruireConnexionEtCommande();

			return listeStocks;
		}
		#endregion

		public override Stock_DAL GetByID(string ID)
		{
			throw new NotImplementedException();
		}

		public Stock_DAL GetByIdBeerAndIdBrewery(string idBeer, string idBrewery)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "Select Quantity, LastUpdate From Stock Where IdBrewery=@IdBrewery AND IdBeer=@IdBeer";
			commande.Parameters.Add(new SqlParameter("@IdBeer", idBeer));
			commande.Parameters.Add(new SqlParameter("@IdBrewery", idBrewery));
			var reader = commande.ExecuteReader();

			var stock = new Stock_DAL(idBrewery,
									idBeer,
									reader.GetInt32(0),
									reader.GetDateTime(1));

			DetruireConnexionEtCommande();

			return stock;
		}

		#region GetByIdBeer
		public Stock_DAL GetByIdBeer(string IdBeer)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT IdBrewery, IdBeer, Quantity, LastUpdate FROM Stock WHERE IdBeer = @IdBeer";
			commande.Parameters.Add(new SqlParameter("@IdBeer", IdBeer));
			var reader = commande.ExecuteReader();

			Stock_DAL stock;
			if (reader.Read())
			{
				stock = new Stock_DAL(reader.GetGuid(0).ToString(),
											reader.GetGuid(1).ToString(),
											reader.GetInt32(2),
											reader.GetDateTime(3));
			}
			else
			{
				throw new Exception($"IdBeer {IdBeer} not found in stock table");
			}

			DetruireConnexionEtCommande();

			return stock;
		}
		#endregion

		#region GetByIdBrewery
		public List<Stock_DAL> GetByIdBrewery(string IdBrewery)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT IdBrewery, IdBeer, Quantity, LastUpdate FROM Stock WHERE IdBrewery = @IdBrewery";
			commande.Parameters.Add(new SqlParameter("@IdBrewery", IdBrewery));
			var reader = commande.ExecuteReader();
			var result = new List<Stock_DAL>();
			while (reader.Read())
			{
				result.Add(new Stock_DAL(reader.GetGuid(0).ToString(),
										reader.GetGuid(1).ToString(),
										reader.GetInt32(2),
										reader.GetDateTime(3)));
			}

			DetruireConnexionEtCommande();

			return result;
		}
		#endregion

		#region Insert
		public override Stock_DAL Insert(Stock_DAL stock)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "INSERT INTO Stock (IdBrewery, IdBeer, Quantity, LastUpdate) VALUES (@IdBrewery, @IdBeer, @Quantity, GETDATE()); SELECT SCOPE_IDENTITY()";
			commande.Parameters.Add(new SqlParameter("@IdBrewery", stock.IdBrewery));
			commande.Parameters.Add(new SqlParameter("@IdBeer", stock.IdBeer));
			commande.Parameters.Add(new SqlParameter("@Quantity", stock.Quantity));

			int nombreDeLignesAffectees = commande.ExecuteNonQuery();

			if (nombreDeLignesAffectees != 1)
			{
				throw new Exception($"{nombreDeLignesAffectees} lignes insérées dans la table Stock");
			}

			DetruireConnexionEtCommande();

			return stock;
		}
		#endregion

		#region Update
		public override Stock_DAL Update(Stock_DAL stock)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "UPDATE Stock SET Quantity=@Quantity, LastUpdate=GETDATE() WHERE IdBrewery=@IdBrewery AND IdBeer=@IdBeer";
			commande.Parameters.Add(new SqlParameter("@Quantity", stock.Quantity));
			commande.Parameters.Add(new SqlParameter("@IdBrewery", stock.IdBrewery));
			commande.Parameters.Add(new SqlParameter("@IdBeer", stock.IdBeer));

			var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

			if (nombreDeLignesAffectees != 1)
			{
				throw new Exception($"Impossible to update stock with IdBeer : {stock.IdBeer}, IdBrewery : {stock.IdBrewery}");
			}

			DetruireConnexionEtCommande();

			return stock;
		}
		#endregion

		#region Delete
		public override void Delete(Stock_DAL stock)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "DELETE FROM Brewery WHERE IdBrewery=@IdBrewery AND IdBeer=@IdBeer";
			commande.Parameters.Add(new SqlParameter("@IdBrewery", stock.IdBrewery));
			commande.Parameters.Add(new SqlParameter("@IdBeer", stock.IdBeer));
			var nombreDeLignesAffectees = commande.ExecuteNonQuery();

			if (nombreDeLignesAffectees != 1)
			{
				throw new Exception($"Impossible to delete stock with IdBeer : {stock.IdBeer}, IdBrewery : {stock.IdBrewery}");
			}

			DetruireConnexionEtCommande();
		}
		#endregion
	}
}
