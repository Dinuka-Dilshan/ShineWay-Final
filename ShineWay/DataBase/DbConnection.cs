using MySql.Data.MySqlClient;
using System;

namespace ShineWay.DataBase
{
    class DbConnection
    {
        private static string connectionString = "datasource=localhost; username=root; password=; database=shineway";

        public static MySqlDataReader Read(string query)
        {

            MySqlDataReader reader = null;
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reader;
            
        }

        public static void Write(string query)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(string query)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Update(string query)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
