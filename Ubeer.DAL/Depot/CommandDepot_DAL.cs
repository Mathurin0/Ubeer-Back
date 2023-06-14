using Microsoft.Data.SqlClient;
using Ubeer.DAL.DAL;
using System;
using System.Collections.Generic;

namespace Ubeer.DAL.Depot
{
    public class CommandDepot_DAL : Depot_DAL<Command_DAL>
    {
        public override List<Command_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "SELECT ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate FROM Address";
            var reader = commande.ExecuteReader();

            var commandList = new List<Command_DAL>();

            while (reader.Read())
            {
                var command = new Command_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDateTime(2),
                                        reader.GetDateTime(3),
                                        reader.GetDateTime(4),
                                        reader.GetDateTime(5)
                                        );

                commandList.Add(command);
            }

            DetruireConnexionEtCommande();

            return commandList;
        }

        public override Command_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate FROM command WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Command_DAL command;
            if (reader.Read())
            {
                command = new Command_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDateTime(2),
                                        reader.GetDateTime(3),
                                        reader.GetDateTime(4),
										reader.GetDateTime(5)
										);
            }
            else
            {
                throw new Exception($"No occurrence of ID {ID} in command table");
            }

            DetruireConnexionEtCommande();

            return command;
        }

        public List<Command_DAL> GetByIdUser(int ID_User)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate FROM command WHERE IdUser=@IdUser";
            commande.Parameters.Add(new SqlParameter("@IdUser", ID_User));
            var reader = commande.ExecuteReader();

            var commandUserlist = new List<Command_DAL>();

            while (reader.Read())
            {
                var item = new Command_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDateTime(2),
                                        reader.GetDateTime(3),
                                        reader.GetDateTime(4),
										reader.GetDateTime(5)
										);
                commandUserlist.Add(item);
            }

            DetruireConnexionEtCommande();

            return commandUserlist;
        }

        public List<Command_DAL> GetByIdAddress(int ID_Address)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate FROM command WHERE IdAddress=@IdAddress";
            commande.Parameters.Add(new SqlParameter("@IdAddress", ID_Address));
            var reader = commande.ExecuteReader();

            var commandAddresslist = new List<Command_DAL>();

            while (reader.Read())
            {
                var item = new Command_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDateTime(2),
                                        reader.GetDateTime(3),
                                        reader.GetDateTime(4),
										reader.GetDateTime(5)
										);
                commandAddresslist.Add(item);
            }

            DetruireConnexionEtCommande();

            return commandAddresslist;
        }


        public override Command_DAL Insert(Command_DAL command)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Command (orderdate, estimateddeliverydate, realdeliverydate, LastUpdate) VALUES (@OrderDate, @EstimatedDeliveryDate, @RealDeliveryDate, GETDATE()); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@OrderDate", command.OrderDate));
            commande.Parameters.Add(new SqlParameter("@EstimatedDeliveryDate", command.EstimatedDeliveryDate));
            commande.Parameters.Add(new SqlParameter("@RealDeliveryDate", command.RealDeliveryDate));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            command.ID = ID;

            DetruireConnexionEtCommande();

            return command;
        }

        public override Command_DAL Update(Command_DAL command)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Address SET orderdate=@OrderDate, estimateddeliverydate=@EstimatedDeliveryDate, realdeliverydate=@RealDeliveryDate, LastUpdate=GETDATE() WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@OrderDate", command.OrderDate));
            commande.Parameters.Add(new SqlParameter("@EstimatedDeliveryDate", command.EstimatedDeliveryDate));
            commande.Parameters.Add(new SqlParameter("@RealDeliveryDate", command.RealDeliveryDate));

            var affectedRow = (int)commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to update command ID : {command.ID}");
            }

            DetruireConnexionEtCommande();

            return command;
        }

        public override void Delete(Command_DAL command)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM command WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", command.ID));
            var affectedRow = commande.ExecuteNonQuery();

            if (affectedRow != 1)
            {
                throw new Exception($"Unable to delete command ID {command.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
