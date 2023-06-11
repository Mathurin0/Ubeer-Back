using Microsoft.Data.SqlClient;
using System.Net;
using Ubeer.DAL.DAL;

namespace Ubeer.DAL.Depot
{
    public class BeerDepot_DAL : Depot_DAL<Beer_DAL>
    {
        public override List<Beer_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT ID, StyleId, Libelle, AlcoholVolume, UnitPrice FROM Beer";
            var reader = commande.ExecuteReader();

            var beerList = new List<Beer_DAL>();

            while (reader.Read())
            {
                var item = new Beer_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetString(2),
                                        reader.GetFloat(3),
                                        reader.GetFloat(4)
                                        );

                beerList.Add(item);
            }

            DetruireConnexionEtCommande();

            return beerList;
        }

        public override Beer_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, StyleId, Libelle, AlcoholVolume, UnitPrice FROM Beer WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Beer_DAL beer;
            if (reader.Read())
            {
                beer = new Beer_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetString(2),
                                        reader.GetFloat(3),
                                        reader.GetFloat(4)
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

            commande.CommandText = "INSERT INTO Beer (libelle, alcoholvolume, unitprice) VALUES (@Libelle, @AlcoholVolume, @UnitPrice); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Libelle", beer.Libelle));
            commande.Parameters.Add(new SqlParameter("@AlcoholVolume", beer.AlcoholVolume));
            commande.Parameters.Add(new SqlParameter("@UnitPrice", beer.UnitPrice));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            beer.ID = ID;

            DetruireConnexionEtCommande();

            return beer;
        }

        public override Beer_DAL Update(Beer_DAL beer)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Beer SET libelle=@Libelle, alcoholvolume=@AlcoholVolume, unitprice=@UnitPrice, WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@Libelle", beer.Libelle));
            commande.Parameters.Add(new SqlParameter("@AlcoholVolume", beer.AlcoholVolume));
            commande.Parameters.Add(new SqlParameter("@UnitPrice", beer.UnitPrice));

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
