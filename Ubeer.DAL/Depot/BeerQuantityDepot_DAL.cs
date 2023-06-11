﻿using Microsoft.Data.SqlClient;
using Ubeer.DAL.DAL;

namespace Ubeer.DAL.Depot
{
    public class BeerQuantityDepot_DAL : Depot_DAL<BeerQuantity_DAL>
    {
        public override List<BeerQuantity_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT IdBeer, IdCommand, Quantity FROM BeerQuantity";
            var reader = commande.ExecuteReader();

            var beerQuantityList = new List<BeerQuantity_DAL>();

            while (reader.Read())
            {
                var item = new BeerQuantity_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                        );

                beerQuantityList.Add(item);
            }

            DetruireConnexionEtCommande();

            return beerQuantityList;
        }

        public override BeerQuantity_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<BeerQuantity_DAL> GetByIdBeer(int ID_Beer)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT IdBeer, IdCommand, Quantity FROM command WHERE IdBeer=@IdBeer";
            commande.Parameters.Add(new SqlParameter("@IdBeer", ID_Beer));
            var reader = commande.ExecuteReader();

            var beerQuantitylist = new List<BeerQuantity_DAL>();

            while (reader.Read())
            {
                var item = new BeerQuantity_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                        );
                beerQuantitylist.Add(item);
            }

            DetruireConnexionEtCommande();

            return beerQuantitylist;
        }

        public List<BeerQuantity_DAL> GetByIdCommand(int ID_Command)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT IdBeer, IdCommand, Quantity FROM command WHERE IdCommand=@IdCommand";
            commande.Parameters.Add(new SqlParameter("@IdCommand", ID_Command));
            var reader = commande.ExecuteReader();

            var beerQuantitylist = new List<BeerQuantity_DAL>();

            while (reader.Read())
            {
                var item = new BeerQuantity_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                        );
                beerQuantitylist.Add(item);
            }

            DetruireConnexionEtCommande();

            return beerQuantitylist;
        }



        public override BeerQuantity_DAL Insert(BeerQuantity_DAL beerQuantity)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Command (idbeer, idcommand, quantity) VALUES (@IdBeer, @IdCommand, @Quantity); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@IdBeer", beerQuantity.IdBeer));
            commande.Parameters.Add(new SqlParameter("@IdCommand", beerQuantity.IdCommand));
            commande.Parameters.Add(new SqlParameter("@Quantity", beerQuantity.Quantity));
            commande.ExecuteNonQuery();


            DetruireConnexionEtCommande();

            return beerQuantity;
        }

        public override BeerQuantity_DAL Update(BeerQuantity_DAL liaison)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID_Beer, int ID_Command)
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
