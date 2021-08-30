using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInLib
{
    public class Account_Client
    {
        public void InsertAccountClient(int myAccountId, int clientId, int status=1, bool inviteAccepted=false)
        {
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("INSERT INTO public.account_client (account_fk, client_fk, invite_accepted, status_changed_date, status_system_fk) VALUES(@account_fk::bigint, @client_fk::bigint, @invite_accepted::boolean, @status_changed_date::timestamp without time zone, @status_system_fk::bigint)", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("account_fk", myAccountId);
                    cmd.Parameters.AddWithValue("client_fk", clientId);
                    cmd.Parameters.AddWithValue("status_system_fk", status);
                    cmd.Parameters.AddWithValue("invite_accepted", inviteAccepted);
                    cmd.Parameters.AddWithValue("status_changed_date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                
            }
            LinkedInController.logger.Info("Account_client inserted");
        }

        public bool GetInviteState(int myAccountId, int clientId)
        {
            bool status = false;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT invite_accepted FROM public.account_client WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("account_fk", myAccountId);
                cmd.Parameters.AddWithValue("client_fk", clientId);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr["invite_accepted"] != DBNull.Value ? Convert.ToBoolean(dr["invite_accepted"]) : throw new Exception("invite_accepted value was null");
                }
               
            }
            return status;
        }

        public void SetInviteAccepted(int myAccountId, int clientId, bool inviteAccepted)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("UPDATE public.account_client SET invite_accepted = @invite_accepted::boolean WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("account_fk", myAccountId);
            cmd.Parameters.AddWithValue("client_fk", clientId);
            cmd.Parameters.AddWithValue("invite_accepted", inviteAccepted);
            cmd.ExecuteNonQuery();
        }

        public static DateTime GetStatusChangedDate(int myAccountId, int clientId)
        {
            DateTime statusChangedDate = DateTime.MinValue;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT status_changed_date FROM public.account_client WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("account_fk", myAccountId);
                cmd.Parameters.AddWithValue("client_fk", clientId);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    statusChangedDate = dr["status_changed_date"] != DBNull.Value ? (Convert.ToDateTime(dr["status_changed_date"])): DateTime.MinValue; // apply in other places
                }
            }
            return statusChangedDate;
        }

        public void SetNotify(int myAccountId, int clientId, bool notify)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("UPDATE public.account_client SET notify = @notify::boolean WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("account_fk", myAccountId);
            cmd.Parameters.AddWithValue("client_fk", clientId);
            cmd.Parameters.AddWithValue("notify", notify);
            cmd.ExecuteNonQuery();
        }

        public bool GetNotify(int myAccountId, int clientId)
        {
            bool notify = false;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT notify FROM public.account_client WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("account_fk", myAccountId);
                cmd.Parameters.AddWithValue("client_fk", clientId);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    notify = dr["notify"] != DBNull.Value ? Convert.ToBoolean(dr["notify"]) : false;
                }

            }
            return notify;
        }

        public bool CheckIfClientNotify(int clientId)
        {
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT notify FROM public.account_client WHERE client_fk = @client_fk::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("client_fk", clientId);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["notify"] != DBNull.Value ? Convert.ToBoolean(dr["notify"]) : false) return true;
                }

            }
            return false;
        }

        public bool CheckIfAccountNotify(int myAccountId)
        {
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT notify FROM public.account_client WHERE account_fk = @account_fk::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("account_fk", myAccountId);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["notify"] != DBNull.Value ? Convert.ToBoolean(dr["notify"]) : false) return true;
                }

            }
            return false;
        }

        public void RemoveAccountClientUsingClientId(int clientId)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using (var cmd = new NpgsqlCommand("DELETE FROM public.account_client WHERE client_fk = (@client_fk::bigint);", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("client_fk", clientId);
                cmd.ExecuteNonQuery();
            }
            LinkedInController.logger.Info($"Removed account_client with Client Id: {clientId} from database");
        }

        public void RemoveAccountClientUsingAccountId(int myAccountId)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using (var cmd = new NpgsqlCommand("DELETE FROM public.account_client WHERE account_fk = (@account_fk::bigint);", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("account_fk", myAccountId);
                cmd.ExecuteNonQuery();
            }
            LinkedInController.logger.Info($"Removed account_client with account Id: {myAccountId} from database");
        }

        public void ChangeSystemStatus(int myAccountId, int clientId, int newStatus)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("UPDATE public.Account_client SET status_system_fk = @status::bigint, status_changed_date = @status_changed_date::timestamp without time zone WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("account_fk", myAccountId);
            cmd.Parameters.AddWithValue("client_fk", clientId);
            cmd.Parameters.AddWithValue("status", newStatus);
            cmd.Parameters.AddWithValue("status_changed_date", DateTime.Now);
            cmd.ExecuteNonQuery();
        }

        public int GetSystemStatusId(int myAccountId, int clientId)
        {
            int status = 0;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT status_system_fk FROM public.account_client WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("account_fk", myAccountId);
                cmd.Parameters.AddWithValue("client_fk", clientId);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr["status_system_fk"] != DBNull.Value ? Convert.ToInt32(dr["status_system_fk"]) : 0;
                }
            }
            return status;
        }

        public List<string> GetSystemStatusesStrings()
        {

            List<string> status = new List<string>();
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT status FROM public.status_system;", conn);
                conn.Open();
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status.Add(dr["status"] != DBNull.Value ? Convert.ToString(dr["status"]) : "Error: received DBValue.null"); // apply in other places
                }
            }
            return status;

        }

        #region User status

        public int GetUserStatusId(int myAccountId, int clientId)
        {
            int status = 0;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT status_user_fk FROM public.account_client WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("account_fk", myAccountId);
                cmd.Parameters.AddWithValue("client_fk", clientId);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr["status_user_fk"] != DBNull.Value ? Convert.ToInt32(dr["status_user_fk"]) : 0;
                }
            }
            return status;
        }

        public int GetUserStatusId(string status)
        {
            int statusId = 0;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT id FROM public.status_user WHERE status = @status::text;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("status", status);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    statusId = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                }
            }
            return statusId;
        }

        public int GetUserStatusIndex(int id) // checks how many rows are before this status
        {
            int status = 0;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT COUNT(*) id FROM public.status_user WHERE id<@id;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("id", id + 1);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr[0] != DBNull.Value ? Convert.ToInt32(dr[0]) : 0;
                }
            }
            return status;
        }

        public bool InsertUserStatus(string status)
        {
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("INSERT INTO public.status_user (status) VALUES(@status)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("status", status);
                cmd.ExecuteNonQuery();
            }
            LinkedInController.logger.Info($"status_user: {status} inserted");
            return true;
        }

        public bool RemoveUserStatus(int id)
        {
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("DELETE FROM public.status_user WHERE id = (@id::bigint);", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
            LinkedInController.logger.Info($"status_user id:{id} removed");
            return true;
        }

        public bool RemoveUserStatus(string status)
        {
            int statusId = 0;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                // Get status id
                using var cmdSel = new NpgsqlCommand("SELECT id FROM public.status_user WHERE status = (@status::text);", conn);
                conn.Open();
                cmdSel.Parameters.AddWithValue("status", status);
                using NpgsqlDataReader dr = cmdSel.ExecuteReader();
                while (dr.Read())
                {
                    statusId = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                }
            }

            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                // Unassign status
                using var cmdUpd = new NpgsqlCommand("UPDATE public.account_client SET status_user_fk = @status_user_fk::bigint WHERE status_user_fk = @statusId::bigint;", conn);
                conn.Open();
                cmdUpd.Parameters.AddWithValue("status_user_fk", DBNull.Value);
                cmdUpd.Parameters.AddWithValue("statusId", statusId);
                cmdUpd.ExecuteNonQuery();
            }

            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                // Delete status
                using var cmdDel = new NpgsqlCommand("DELETE FROM public.status_user WHERE id = (@id::bigint);", conn);
                conn.Open();
                cmdDel.Parameters.AddWithValue("id", statusId);
                cmdDel.ExecuteNonQuery();
            }
            
            LinkedInController.logger.Info($"status_user status:{status} removed, referenced clients unassigned.");
            return true;
        }

        public bool ChangeUserStatus(int myAccountId, int clientId, int newStatus)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("UPDATE public.Account_client SET status_user_fk = @status::bigint WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("account_fk", myAccountId);
            cmd.Parameters.AddWithValue("client_fk", clientId);
            cmd.Parameters.AddWithValue("status", newStatus);
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool UnassignUserStatus(int myAccountId, int clientId)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("UPDATE public.Account_client SET status_user_fk = @status::bigint WHERE account_fk = @account_fk::bigint AND client_fk = @client_fk::bigint;", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("account_fk", myAccountId);
            cmd.Parameters.AddWithValue("client_fk", clientId);
            cmd.Parameters.AddWithValue("status", DBNull.Value);
            cmd.ExecuteNonQuery();
            LinkedInController.logger.Info($"User status is now unassigned for account: {myAccountId} and client: {clientId}");
            return true;
        }

        public string GetUserStatusText(int id)
        {

            string status = null;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT status FROM public.status_user WHERE id = @id::bigint;", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("id", id);
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr["status"] != DBNull.Value ? Convert.ToString(dr["status"]) : "Error: received DBValue.null"; // apply in other places
                }
            }
            if (string.IsNullOrEmpty(status))
            {
                return "Error: received DBValue.null";
            }
            else return status;

        }

        public List<string> GetUserStatusesStrings()
        {

            List<string> status = new List<string>();
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using var cmd = new NpgsqlCommand("SELECT status FROM public.status_user;", conn);
                conn.Open();
                using NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status.Add(dr["status"] != DBNull.Value ? Convert.ToString(dr["status"]) : "Error: received DBValue.null"); // apply in other places
                }
            }
            return status;

        }

        #endregion

    }
}
