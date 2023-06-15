using Microsoft.Data.SqlClient;
using Ubeer.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Ubeer.DAL.Depot
{
    public class BeerQuantityDepot_DAL : Depot_DAL<BeerQuantity_DAL>
    {
        public override List<BeerQuantity_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT IdBeer, IdCommand, Quantity, LastUpdate FROM BeerQuantity";
            var reader = commande.ExecuteReader();

            var beerQuantityList = new List<BeerQuantity_DAL>();

            while (reader.Read())
            {
                var item = new BeerQuantity_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetInt32(2),
										reader.GetDateTime(3)
										);

                beerQuantityList.Add(item);
            }

            DetruireConnexionEtCommande();

            return beerQuantityList;
        }

        public override BeerQuantity_DAL GetByID(string ID)
        {
            throw new NotImplementedException();
        }

        public BeerQuantity_DAL GetByIdBeerAndIdCommand(string idBeer, string idCommand)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "Select Quantity, LastUpdate From BeerQuantity Where IdBeer=@IdBeer And IdCommand=@IdCommand";
            commande.Parameters.Add(new SqlParameter("@IdBeer", idBeer));
            commande.Parameters.Add(new SqlParameter("@IdCommand", idCommand));
            var reader = commande.ExecuteReader();
            BeerQuantity_DAL beerQuantity;

            if (reader.Read())
            {
				beerQuantity = new BeerQuantity_DAL(idBeer, idCommand, reader.GetInt32(0),
																	reader.GetDateTime(1));
			}
			else
			{
				throw new Exception($"No occurrence of IdBeer {idBeer}, IdCommand {idCommand} in BeerQuantity table");
			}

            DetruireConnexionEtCommande();

            return beerQuantity;
        }

        public List<BeerQuantity_DAL> GetByIdBeer(string ID_Beer)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT IdBeer, IdCommand, Quantity, LastUpdate FROM BeerQuantity WHERE IdBeer=@IdBeer";
            commande.Parameters.Add(new SqlParameter("@IdBeer", ID_Beer));
            var reader = commande.ExecuteReader();

            var beerQuantitylist = new List<BeerQuantity_DAL>();

            while (reader.Read())
            {
                var item = new BeerQuantity_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetInt32(2),
										reader.GetDateTime(3)
										);
                beerQuantitylist.Add(item);
            }

            DetruireConnexionEtCommande();

            return beerQuantitylist;
        }

        public List<BeerQuantity_DAL> GetByIdCommand(string ID_Command)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT IdBeer, IdCommand, Quantity, LastUpdate FROM BeerQuantity WHERE IdCommand=@IdCommand";
            commande.Parameters.Add(new SqlParameter("@IdCommand", ID_Command));
            var reader = commande.ExecuteReader();

            var beerQuantitylist = new List<BeerQuantity_DAL>();

            while (reader.Read())
            {
                var item = new BeerQuantity_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetInt32(2),
										reader.GetDateTime(3)
										);
                beerQuantitylist.Add(item);
            }

            DetruireConnexionEtCommande();

            return beerQuantitylist;
        }



        public override BeerQuantity_DAL Insert(BeerQuantity_DAL beerQuantity)
        {
            CreerConnexionEtCommande();

			commande.CommandText = "INSERT INTO BeerQuantity (IdBeer, IdCommand, Quantity, LastUpdate) VALUES (@IdBeer, @IdCommand, @Quantity, GETDATE()); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@IdBeer", beerQuantity.IdBeer));
            commande.Parameters.Add(new SqlParameter("@IdCommand", beerQuantity.IdCommand));
            commande.Parameters.Add(new SqlParameter("@Quantity", beerQuantity.Quantity));

			int nbLinesAffected = commande.ExecuteNonQuery();

			if (nbLinesAffected != 1)
			{
				throw new Exception($"{nbLinesAffected} lignes affectées dans la table BeerQuantity");
			}


			DetruireConnexionEtCommande();

            return beerQuantity;
        }

        public override BeerQuantity_DAL Update(BeerQuantity_DAL liaison)
        {
            throw new NotImplementedException();
        }

        public void Delete(string ID_Beer, string ID_Command)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM BeerQuantity WHERE ID_Beer=@IdBeer and ID_Command=@IdCommand";
            commande.Parameters.Add(new SqlParameter("@ID_produit", ID_Beer));
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_Command));
            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();
        }

        public override void Delete(BeerQuantity_DAL item)
        {
            throw new NotImplementedException();
        }
    }
}
