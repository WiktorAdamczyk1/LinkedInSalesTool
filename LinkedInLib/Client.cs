using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInLib
{   
    public class Client
    {

        public void InsertClient(string profileAddress)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("INSERT INTO public.client (profile_address) VALUES(@profile_address::character varying[]);", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("profile_address", $"{{{profileAddress}}}");
            cmd.ExecuteNonQuery();
        }

        public void InsertClient(string profileAddress, string name)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("INSERT INTO public.client (profile_address, name) VALUES(@profile_address::character varying[], @name::character varying[]);", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("profile_address", $"{{{profileAddress}}}");
            cmd.Parameters.AddWithValue("name", $"{{{name}}}");
            cmd.ExecuteNonQuery();
        }

        public void RemoveClient(int id)
        {
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("DELETE FROM public.client WHERE id = (@id::bigint);", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
                LinkedInController.logger.Info($"Removed client with id:{id}");
            }
        }

        public void RemoveClient(string profileAddress)
        {
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("DELETE FROM public.client WHERE profile_address = (@profile_address::character varying[]);", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("profile_address", $"{{{profileAddress}}}");
                    cmd.ExecuteNonQuery();
                }
                LinkedInController.logger.Info($"Removed client with profile address: {profileAddress}");
            }
        }

        public long GetClientId(string profileAddress)
        {
            long id = long.MaxValue;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT id FROM public.client where profile_address = @profile_address::character varying[];", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("profile_address", $"{{{profileAddress}}}");
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = (dr["id"] != DBNull.Value ? Convert.ToInt64(dr["id"]) : 0); // apply in other places
                }
            }
            return id;
        }

        public string GetClientName(int id)
        {
            string name = null;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT name FROM public.client where id = @id::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("id", id);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name = dr["name"] != DBNull.Value ? ((string[])dr["name"])[0] : "Error: name value was null"; // apply in other places
                }
            }
            return name;
        }

        public string GetClientName(string profileAddress)
        {
            string name = null;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT name FROM public.client where profile_address = @profile_address::character varying[];", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("profile_address", $"{{{profileAddress}}}");
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name = (dr["name"] != DBNull.Value ? Convert.ToString(dr["name"]) : "Error: name value was null"); // apply in other places
                }
            }
            return name;
        }

        public string GetClientProfileAddress(int id)
        {
            string profile_address = null;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT profile_address FROM public.client where id = @id::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("id", id);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    profile_address = dr["profile_address"] != DBNull.Value ? ((string[])dr["profile_address"])[0] : "Error: profile_address value was null"; // apply in other places
                }
            }
            return profile_address;
        }

        public List<ClientData> GetAllClientsData()
        {
            List<ClientData> clientDatas = new List<ClientData>();
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT id, name, profile_address, assigned_account FROM public.client;", conn);
                conn.Open();
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClientData clientData = new ClientData();
                    clientData.Id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : -1;
                    clientData.Name = dr["name"] != DBNull.Value ? ((string[])dr["name"])[0] : "Error: name value was null";
                    clientData.ProfileAddress = dr["profile_address"] != DBNull.Value ? ((string[])dr["profile_address"])[0] : "Error: profile_address value was null";
                    clientData.AssignedAccount = dr["assigned_account"] != DBNull.Value ? Convert.ToInt32(dr["assigned_account"]) : -1;
                    clientDatas.Add(clientData);
                }
            }

            return clientDatas;
        }

        public bool CheckIfClientAlreadyAdded(string profileAddress)
        {
            int receivedRows = -1;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("SELECT COUNT(1) FROM public.client WHERE  profile_address = (@profile_address::character varying[]);", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("profile_address", $"{{{profileAddress}}}");


                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            receivedRows = dr[0] != DBNull.Value ? Convert.ToInt32(dr[0]) : -1;
                        }
                    }
                }
            }

            if (receivedRows > 0)
            {
                LinkedInController.logger.Info("Client exists in db");
                return true;
            }
            else if (receivedRows == 0)
            {
                LinkedInController.logger.Info("Client doesn't exist in db");
                return false;
            }
            else
            {
                throw new Exception("Encountered an error while checking if Client exists in db (received null when counting rows)");
            }
        }

        public bool AssignAccountToClient(int myAccountId, int clientId)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("UPDATE public.Client SET assigned_account = @account_id::bigint WHERE id = @id;", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("id", clientId);
            cmd.Parameters.AddWithValue("account_id", myAccountId);
            cmd.ExecuteNonQuery();
            LinkedInController.logger.Info($"AccountId {myAccountId} was assigned to clientId {clientId}");
            return true;
        }

        public int ReassignClientAfterAccountDeletition(ClientData clientData) //clientData.assignedAccount == deleted account id
        {
            Account account = new Account();
            int newAssignedAccountId = account.GetNextAccount(clientData.AssignedAccount);
            if (newAssignedAccountId != -1)
                AssignAccountToClient(newAssignedAccountId, clientData.Id);
            else
            {
                AssignAccountToClient(0, clientData.Id);
            }
            return newAssignedAccountId;

        }

    }
}
