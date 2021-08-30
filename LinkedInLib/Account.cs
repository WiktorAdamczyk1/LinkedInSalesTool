using Npgsql;
using System;
using System.Collections.Generic;

namespace LinkedInLib
{
    public struct AccountCreditentials // every account has to be in db (change to class and make constructor insert it?)
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Special { get; set; }
    }

    public class Account
    {
        public void InsertAccount(string email, string password, string name=null, bool special = false)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            string command = null;
            if (name == null) command = "INSERT INTO public.account(email, password, special) VALUES(@email::character varying[], @password::character varying[], @special::boolean) returning id;";
            else command = "INSERT INTO public.account(email, password, name, special) VALUES(@email::character varying[], @password::character varying[], @name::character varying[], @special::boolean) returning id;";
            using var cmd = new NpgsqlCommand(command, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("email", $"{{{email}}}");
            cmd.Parameters.AddWithValue("password", $"{{{password}}}");
            if (name != null) cmd.Parameters.AddWithValue("name", $"{{{name}}}");
            cmd.Parameters.AddWithValue("special", special);
            cmd.ExecuteNonQuery();
        }

        public AccountCreditentials GetAccountCreditentials(int id)
        {
            AccountCreditentials accountCreditentials = new AccountCreditentials();
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            {
                using var cmd = new NpgsqlCommand("SELECT id, email, password, name, special FROM public.account WHERE id = @id::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("id", id);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    accountCreditentials.Id = id = (dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0);
                    accountCreditentials.Email = dr["email"] != DBNull.Value ? ((string[])dr["email"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Password = dr["password"] != DBNull.Value ? ((string[])dr["password"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Name = dr["name"] != DBNull.Value ? ((string[])dr["name"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Special = dr["special"] != DBNull.Value ? Convert.ToBoolean(dr["special"]) : false;
                }
            }

            return accountCreditentials;
        }

        public AccountCreditentials GetFirstAccountCreditentials()
        {
            AccountCreditentials accountCreditentials = new AccountCreditentials();
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            {
                using var cmd = new NpgsqlCommand("SELECT id, email, password, name, special FROM public.account ORDER BY id ASC LIMIT 1;", conn);
                conn.Open();
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    accountCreditentials.Id = (dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0);
                    accountCreditentials.Email = dr["email"] != DBNull.Value ? ((string[])dr["email"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Password = dr["password"] != DBNull.Value ? ((string[])dr["password"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Name = dr["name"] != DBNull.Value ? ((string[])dr["name"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Special = dr["special"] != DBNull.Value ? Convert.ToBoolean(dr["special"]) : false;
                }
            }

            return accountCreditentials;
        }

        public List<AccountCreditentials> GetAllAccountsCreditentials()
        {
            List<AccountCreditentials> accountCreditentialsList = new List<AccountCreditentials>();
            
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            {
                using var cmd = new NpgsqlCommand("SELECT id, email, password, name, special FROM public.account;", conn);
                conn.Open();
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AccountCreditentials accountCreditentials = new AccountCreditentials();
                    accountCreditentials.Id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : -1;
                    accountCreditentials.Email = dr["email"] != DBNull.Value ? ((string[])dr["email"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Password = dr["password"] != DBNull.Value ? ((string[])dr["password"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Name = dr["name"] != DBNull.Value ? ((string[])dr["name"])[0] : "Error: DBNull.value received";
                    accountCreditentials.Special = dr["special"] != DBNull.Value ? Convert.ToBoolean(dr["special"]) : false;
                    accountCreditentialsList.Add(accountCreditentials);
                }
            }

            return accountCreditentialsList;
        }

        public void RemoveAccount(string email)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using (var cmd = new NpgsqlCommand("DELETE FROM public.account WHERE email = (@email::character varying[]);", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("email", $"{{{email}}}");
                cmd.ExecuteNonQuery();
            }
            LinkedInController.logger.Info($"Removed account with email: {email} from database");
        }

        public void RemoveAccount(int id)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using (var cmd = new NpgsqlCommand("DELETE FROM public.account WHERE id = (@id::bigint);", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
            LinkedInController.logger.Info($"Removed account with id: {id} from database");
        }

        public bool CheckIfAccountAlreadyAdded(string email)
        {
            int receivedRows = -1;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("SELECT COUNT(1) FROM public.account WHERE email = (@email::character varying[]);", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("email", $"{{{email}}}");


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
                LinkedInController.logger.Info("Account exists in db");
                return true;
            }
            else if (receivedRows == 0)
            {
                LinkedInController.logger.Info("Account doesn't exist in db");
                return false;
            }
            else
            {
                throw new Exception("Encountered an error while checking if Account exists in db (received null when counting rows)");
            }
        }

        public int GetAccountId(string email)
        {
            int id = -1;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("SELECT id FROM public.account WHERE email = (@email::character varying[]);", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("email", $"{{{email}}}");


                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : -1;
                        }
                    }
                }
            }

            if (id > 0)
            {
                LinkedInController.logger.Info($"Account id is {id}");
                return id;
            }
            else if (id == -1)
            {
                LinkedInController.logger.Info("Account doesn't exist in db");
                return -1;
            }
            else
            {
                throw new Exception("Encountered an error while checking if Account exists in db");
            }
        }

        internal int GetNextAccount(int myAccountId)
        {
            int id = -1;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("SELECT id FROM public.account WHERE id>@id ORDER BY id ASC LIMIT 1;", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("id", myAccountId);


                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : -1;
                        }
                    }
                }
            }

            if (id > 0)
            {
                LinkedInController.logger.Info($"Next account id is {id}");
                return id;
            }
            else if (id == -1)
            {
                LinkedInController.logger.Info("No accounts with higher id in db");
                return -1;
            }
            else
            {
                throw new Exception("Encountered an error while getting next account id");
            }
        }
    }
}