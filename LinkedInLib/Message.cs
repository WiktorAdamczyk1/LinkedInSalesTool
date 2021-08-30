using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInLib
{
    public class Message
    {
        public bool CheckIfMessageExistsInDb(MessageDetails message)
        {
            int receivedRows = -1;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("SELECT COUNT(1) FROM public.message WHERE account_fk = (@account_fk::bigint) AND client_fk = (@client_fk::bigint) AND text = (@text::text[]) AND time = (@time::time) AND sent_by_client = (@sent_by_client::boolean);", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("account_fk", message.Account_fk.ToString());
                    cmd.Parameters.AddWithValue("client_fk", message.Client_fk.ToString());
                    cmd.Parameters.AddWithValue("text", $"{{{message.Text}}}");
                    cmd.Parameters.AddWithValue("date", message.Date);
                    cmd.Parameters.AddWithValue("time", message.Time);
                    cmd.Parameters.AddWithValue("sent_by_client", message.Sent_by_client);
                    cmd.Parameters.AddWithValue("read", message.Read);

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
                LinkedInController.logger.Info("Message exists in db");
                return true;
            }
            else if (receivedRows == 0)
            {
                LinkedInController.logger.Info("Message doesn't exist in db");
                return false;
            }
            else
            {
                throw new Exception("Encountered an error while checking if message exists in db (received null when counting rows)");
            }
        }

        public List<MessageDetails> SelectMessagesWithClient(int myAccountId, int clientId)
        {
            List<MessageDetails> messages = new List<MessageDetails>();
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("SELECT id, text, date, time, sent_by_client, read FROM public.message WHERE account_fk = (@account_fk::bigint) AND client_fk = (@client_fk::bigint) ORDER BY id ASC;", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("account_fk", myAccountId.ToString());
                    cmd.Parameters.AddWithValue("client_fk", clientId.ToString());

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            MessageDetails messageDetails = new MessageDetails();
                            messageDetails.Id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : -1;
                            messageDetails.Text = dr["text"] != DBNull.Value ? ((string[])dr["text"])[0] : "Error: DBNull.value received";
                            messageDetails.Date = dr["date"] != DBNull.Value ? Convert.ToString(dr["date"]) : "Error: DBNull.value received";
                            messageDetails.Date = messageDetails.Date.Split(" ")[0];
                            messageDetails.Time = dr["time"] != DBNull.Value ? Convert.ToString(dr["time"]).Substring(0,5) : "Error: DBNull.value received";
                            messageDetails.Sent_by_client = dr["sent_by_client"] != DBNull.Value ? Convert.ToBoolean(dr["sent_by_client"]) : throw new Exception("sent_by_client value was null");
                            messageDetails.Read = dr["read"] != DBNull.Value ? Convert.ToBoolean(dr["read"]) : throw new Exception("read value was null");
                            messages.Add(messageDetails);
                        }
                    }
                }
            }

            if (messages.Count > 0)
            {
                SetChatAsRead(myAccountId, clientId);
                LinkedInController.logger.Info($"Returning {messages.Count} messages");
                return messages;
            }
            else if (messages.Count == 0)
            {
                LinkedInController.logger.Info("No messages found");
                return messages;
            }
            else
            {
                throw new Exception($"Encountered an error while selecting messages with client clientId:{clientId}");
            }
            
        }

        public void InsertMessage(MessageDetails message)
        {
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("INSERT INTO public.message (account_fk, client_fk, text, date, time, sent_by_client, read) VALUES(@account_fk::bigint, @client_fk::bigint, @text::text[], @date::date, @time::time without time zone, @sent_by_client::boolean, @read::boolean)", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("account_fk", message.Account_fk.ToString());
                    cmd.Parameters.AddWithValue("client_fk", message.Client_fk.ToString());
                    cmd.Parameters.AddWithValue("text", $"{{{message.Text}}}");
                    cmd.Parameters.AddWithValue("date", message.Date);
                    cmd.Parameters.AddWithValue("time", message.Time);
                    cmd.Parameters.AddWithValue("sent_by_client", message.Sent_by_client);
                    cmd.Parameters.AddWithValue("read", message.Read);

                    cmd.ExecuteNonQuery();
                }
                LinkedInController.logger.Info("New message inserted");
            }
        }

        public void InsertMessages(List<MessageDetails> messages)
        {
            bool newMessages = false;   // Reached new messages flag
            foreach (var message in messages)
            {
                if (!newMessages) // Check for new message, after finding one insert everything that comes after without checking
                {
                    if (!CheckIfMessageExistsInDb(message))
                    {
                        newMessages = true;
                        InsertMessage(message);
                    }
                }
                else InsertMessage(message);

            }
        }

        private void SetChatAsRead(int myAccountId, int clientId)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using var cmd = new NpgsqlCommand("UPDATE public.message SET read = true::boolean WHERE account_fk = @account_fk AND client_fk = @client_fk;", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("account_fk", myAccountId);
            cmd.Parameters.AddWithValue("client_fk", clientId);
            cmd.ExecuteNonQuery();
            LinkedInController.logger.Info("Chat set as read");
        }

        public bool CheckIfMessageIsRead(MessageDetails message)
        {
            bool read = false;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("SELECT read FROM public.message WHERE account_fk = (@account_fk::bigint) AND client_fk = (@client_fk::bigint) AND text = (@text::text[]) AND time = (@time::time) AND sent_by_client = (@sent_by_client::boolean);", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("account_fk", message.Account_fk.ToString());
                    cmd.Parameters.AddWithValue("client_fk", message.Client_fk.ToString());
                    cmd.Parameters.AddWithValue("text", $"{{{message.Text}}}");
                    cmd.Parameters.AddWithValue("date", message.Date);
                    cmd.Parameters.AddWithValue("time", message.Time);
                    cmd.Parameters.AddWithValue("sent_by_client", message.Sent_by_client);

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            read = dr["read"] != DBNull.Value ? Convert.ToBoolean(dr["read"]) : false;
                        }
                    }
                }
            }

            return read;
        }

        public void RemoveMessagesWithClient(int myAccountId, int clientId)
        {
            using var conn = new NpgsqlConnection(DatabaseManager.connectionString);
            using (var cmd = new NpgsqlCommand("DELETE FROM public.message WHERE account_fk = (@account_fk::bigint) AND client_fk = (@client_fk::bigint);", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("account_fk", myAccountId);
                cmd.Parameters.AddWithValue("client_fk", clientId);
                cmd.ExecuteNonQuery();
            }
            LinkedInController.logger.Info($"Removed messages between Account Id: {myAccountId} and Client Id: {clientId} from database");
        }

        public string GetNewestMessageTimestamp(int myAccountId, int clientId)
        {
            string timestamp = null;
            using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
            {
                using (var cmd = new NpgsqlCommand("SELECT id, time FROM public.message WHERE account_fk = (@account_fk::bigint) AND client_fk = (@client_fk::bigint) ORDER BY id DESC LIMIT 1;", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("account_fk", myAccountId.ToString());
                    cmd.Parameters.AddWithValue("client_fk", clientId.ToString());

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            timestamp = dr["time"] != DBNull.Value ? Convert.ToString(dr["time"]) : "Error: DBNull.value received";

                        }
                    }
                }
            }
            return timestamp;
        }
    }
}
