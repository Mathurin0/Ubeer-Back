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
		public override List<Stock_DAL> GetAll()
		{
			#region GetAll
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT IdBrewery, IdBeer, Quantity FROM Stock";
			var reader = commande.ExecuteReader();

			var listeStocks = new List<Stock_DAL>();

			while (reader.Read())
			{
				var stock = new Stock_DAL(reader.GetInt32(0),
											reader.GetInt32(1),
											reader.GetInt32(2));

				listeStocks.Add(stock);
			}

			DetruireConnexionEtCommande();

			return listeStocks;
		}
		#endregion

		#region GetByIdBeer
		public override Stock_DAL GetByID(int IdBeer)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT IdBrewery, IdBeer, Quantity FROM Stock WHERE IdBeer = @IdBeer";
			commande.Parameters.Add(new SqlParameter("@IdBeer", IdBeer));
			var reader = commande.ExecuteReader();

			Stock_DAL stock;
			if (reader.Read())
			{
				stock = new Stock_DAL(reader.GetInt32(0),
											reader.GetInt32(1),
											reader.GetInt32(2));
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
		public Stock_DAL GetByIdBrewery(int IdBrewery)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "SELECT IdBrewery, IdBeer, Quantity FROM Stock WHERE IdBrewery = @IdBrewery";
			commande.Parameters.Add(new SqlParameter("@IdBrewery", IdBrewery));
			var reader = commande.ExecuteReader();

			Stock_DAL stock;
			if (reader.Read())
			{
				stock = new Stock_DAL(reader.GetInt32(0),
											reader.GetInt32(1),
											reader.GetInt32(2));
			}
			else
			{
				throw new Exception($"IdBrewery {IdBrewery} not found in stock table");
			}

			DetruireConnexionEtCommande();

			return stock;
		}
		#endregion

		#region Insert
		public override Stock_DAL Insert(Stock_DAL stock)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "INSERT INTO Stock (IdBrewery, IdBeer, Quantity) VALUES (@IdBrewery, @IdBeer, @Quantity); SELECT SCOPE_IDENTITY()";
			commande.Parameters.Add(new SqlParameter("@IdBrewery", stock.IdBrewery));
			commande.Parameters.Add(new SqlParameter("@IdBeer", stock.IdBeer));
			commande.Parameters.Add(new SqlParameter("@Quantity", stock.Quantity));

			DetruireConnexionEtCommande();

			return stock;
		}
		#endregion

		#region Update
		public override Stock_DAL Update(Stock_DAL stock)
		{
			CreerConnexionEtCommande();

			commande.CommandText = "UPDATE Stock SET Quantity=@Quantity WHERE IdBrewery=@IdBrewery AND IdBeer=@IdBeer";
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
