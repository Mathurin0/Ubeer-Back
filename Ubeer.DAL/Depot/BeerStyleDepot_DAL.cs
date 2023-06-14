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
                var item = new BeerStyle_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
										reader.GetDateTime(2),
										reader.GetDateTime(3)
										);

                styleList.Add(item);
            }

            DetruireConnexionEtCommande();

            return styleList;
        }

        public override BeerStyle_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, Libelle, Creation, LastUpdate FROM BeerStyle WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            BeerStyle_DAL style;
            if (reader.Read())
            {
                style = new BeerStyle_DAL(reader.GetInt32(0),
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

            commande.CommandText = "INSERT INTO BeerStyle (libelle, Creation, LastUpdate) VALUES (@Libelle, GETDATE(), GETSATE()); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Libelle", style.Libelle));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            style.ID = ID;

            DetruireConnexionEtCommande();

            return style;
        }

        public override BeerStyle_DAL Update(BeerStyle_DAL style)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE BeerStyle SET libelle=@Libelle, LastUpdate=GETDATE() WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@Libelle", style.Libelle));

            var affectedRow = (int)commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to update beerStyle ID : {style.ID}");
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
