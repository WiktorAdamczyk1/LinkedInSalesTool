using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInLib
{

    public class DatabaseManager
    {
        public static string connectionString;

        public DatabaseManager()
        {
            
        }

        public DatabaseManager(string server, string database, string port, string username, string password)
        {
            connectionString = $"Server={server}; Database={database}; Port={port}; Username={username}; Password={password}";
        }

        public bool ValidConnectionTest()
        {
            try
            {
                using (var conn = new NpgsqlConnection(DatabaseManager.connectionString))
                {
                    conn.Open();
                }
            }
            catch 
            {
                return false;
            }

                return true;
        }

    }
}


