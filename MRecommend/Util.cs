using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms; // for MessageBox
using System;

namespace Movies
{
    public static class Util
    {
        private static MySqlConnection conn;

        // Idempotently open a database connection
        public static MySqlConnection connect()
        {
            if (conn == null)
            {
                conn = new MySqlConnection("server=localhost;User Id=root;database=moviedb");
                conn.Open();
            }
            if (conn.State != ConnectionState.Open)
            {
                // Don't show a messagebox because the error is already shown to the user.
                Application.Exit();
            }
            return conn;
        }

        // Run an SQL query on a specific MySQL table
        public static DataTable query(String sql)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connect());
            DataSet set = new DataSet();
            adapter.Fill(set, "a");
            return set.Tables["a"];
        }

        public static void non_query(String sql)
        {
            new MySqlCommand(sql, connect()).ExecuteNonQuery();
        }
    }
}
