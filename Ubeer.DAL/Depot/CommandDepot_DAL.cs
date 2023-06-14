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
            commande.CommandText = "SELECT ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate FROM Command";
            var reader = commande.ExecuteReader();

            var commandList = new List<Command_DAL>();

            while (reader.Read())
            {
                var command = new Command_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetGuid(2).ToString(),
                                        reader.GetDateTime(3), 
                                        reader.GetDateTime(4), 
                                        reader.GetDateTime(5), 
                                        reader.GetDateTime(6)
                                        );

                commandList.Add(command);
            }

            DetruireConnexionEtCommande();

            return commandList;
        }

        public override Command_DAL GetByID(string ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdAddress, IdUser, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate FROM Command WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Command_DAL command;
            if (reader.Read())
            {
                command = new Command_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetGuid(2).ToString(),
                                        reader.GetDateTime(3),
                                        reader.GetDateTime(4),
                                        reader.GetDateTime(5),
										reader.GetDateTime(6)
										);
            }
            else
            {
                throw new Exception($"No occurrence of ID {ID} in command table");
            }

            DetruireConnexionEtCommande();

            return command;
        }

        public List<Command_DAL> GetByIdUser(string ID_User)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate FROM Command WHERE IdUser=@IdUser";
            commande.Parameters.Add(new SqlParameter("@IdUser", ID_User));
            var reader = commande.ExecuteReader();

            var commandUserlist = new List<Command_DAL>();

            while (reader.Read())
            {
                var item = new Command_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetGuid(2).ToString(),
                                        reader.GetDateTime(3), 
                                        reader.GetDateTime(4), 
                                        reader.GetDateTime(5), 
                                        reader.GetDateTime(6)
										);
                commandUserlist.Add(item);
            }

            DetruireConnexionEtCommande();

            return commandUserlist;
        }

        public List<Command_DAL> GetByIdAddress(string ID_Address)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, IdUser, IdAddress, OrderDate, EstimatedDeliveryDate, RealDeliveryDate, LastUpdate FROM Command WHERE IdAddress=@IdAddress";
            commande.Parameters.Add(new SqlParameter("@IdAddress", ID_Address));
            var reader = commande.ExecuteReader();

            var commandAddresslist = new List<Command_DAL>();

            while (reader.Read())
            {
                var item = new Command_DAL(reader.GetGuid(0).ToString(),
                                        reader.GetGuid(1).ToString(),
                                        reader.GetGuid(2).ToString(),
                                        reader.GetDateTime(3),
                                        reader.GetDateTime(4),
                                        reader.GetDateTime(5),
										reader.GetDateTime(6)
										);
                commandAddresslist.Add(item);
            }

            DetruireConnexionEtCommande();

            return commandAddresslist;
        }


        public override Command_DAL Insert(Command_DAL command)
        {
            CreerConnexionEtCommande();

			//Création de l'ID
			string ID = "";
			while (ID == "")
			{
				Guid guid = Guid.NewGuid();
				ID = guid.ToString();
				commande.CommandText = $"SELECT COUNT(ID) FROM Command WHERE ID = '{ID}'";
				int isIdAlreadyUsed = Convert.ToInt32(commande.ExecuteNonQuery());

				if (isIdAlreadyUsed > 0)
				{
					ID = "";
				}
			}

			commande.CommandText = "INSERT INTO Command (ID, IdUser, IdAddress, orderdate, estimateddeliverydate, realdeliverydate, LastUpdate) VALUES (@ID, @IdUser, @IdAddress, @OrderDate, @EstimatedDeliveryDate, @RealDeliveryDate, GETDATE()); SELECT SCOPE_IDENTITY()";
			commande.Parameters.Add(new SqlParameter("@ID", ID));
			commande.Parameters.Add(new SqlParameter("@IdUser", command.IdUser));
			commande.Parameters.Add(new SqlParameter("@IdAddress", command.IdAddress));
			commande.Parameters.Add(new SqlParameter("@OrderDate", command.OrderDate));
            commande.Parameters.Add(new SqlParameter("@RealDeliveryDate", command.RealDeliveryDate));
			commande.Parameters.Add(new SqlParameter("@EstimatedDeliveryDate", command.EstimatedDeliveryDate));

			int nbLinesAffected = commande.ExecuteNonQuery();

			if (nbLinesAffected != 1)
			{
				throw new Exception($"{nbLinesAffected} lignes affectées dans la table Command");
			}

			DetruireConnexionEtCommande();

            return command;
        }

        public override Command_DAL Update(Command_DAL command)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Command SET OrderDate=@OrderDate, EstimatedDeliveryDate=@EstimatedDeliveryDate, RealDeliveryDate=@RealDeliveryDate, LastUpdate=GETDATE() WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@OrderDate", command.OrderDate));
            commande.Parameters.Add(new SqlParameter("@EstimatedDeliveryDate", command.EstimatedDeliveryDate));
            commande.Parameters.Add(new SqlParameter("@RealDeliveryDate", command.RealDeliveryDate));
			commande.Parameters.Add(new SqlParameter("@ID", command.ID));

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

            commande.CommandText = "DELETE FROM Command WHERE ID=@ID";
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
