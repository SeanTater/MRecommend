using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms; // for MessageBox
using System;

namespace Movies
{
    public static class Util
    {
        private static MySqlConnection conn;

        // Indempotently open a database connection
        private static void connect()
        {
            if (conn == null)
            {
                conn = new MySqlConnection("server=localhost;User Id=root;database=moviedb");
                conn.Open();
            }
            if (conn.State != ConnectionState.Open)
                MessageBox.Show("Connection to database was lost.");
        }

        // Run an SQL query on a specific MySQL table
        public static DataTable query(String sql, String table_name)
        {
            // Often a no-op
            connect();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataSet set = new DataSet();
            adapter.Fill(set, table_name);
            return set.Tables[table_name];
        }
    }
}
