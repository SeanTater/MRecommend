using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms; // for MessageBox
using System.Dynamic;
using System;

namespace Movies
{
    public static class ORM
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

        public static int non_query(String sql)
        {
            return new MySqlCommand(sql, connect()).ExecuteNonQuery();
        }
    }

    abstract public class DBObject : DynamicObject
    {
        public static string table_name;
        public static string[] column_names;
        public DataRow entries;

        private int column_to_index(string name)
        {
            name = name.ToLower();
            for (int i = 0; i < column_names.Length; i++)
                if (column_names[i].ToLower() == name)
                    return i;
            return -1;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            int index = column_to_index(binder.Name);
            if (index < 0)
            {
                result = null;
                return false;
            }
            else
            {
                result = entries[column_to_index(binder.Name)];
                return true;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            int index = column_to_index(binder.Name);
            if (index < 0)
            {
                return false;
            }
            else
            {
                value = entries[column_to_index(binder.Name)];
                return true;
            }
        }

        public static DataRowCollection select(String shortql)
        {
            return ORM.query(string.Format("SELECT * FROM {0} {1}", table_name, shortql)).Rows;
        }

        public static int save()
        {
            string column_name_group = string.Join(", ", column_names);
            return ORM.non_query(string.Format("INSERT INTO {} VALUES ({}) ON DUPLICATE KEY UPDATE;", table_name, column_name_group));
        }
    }

    public class Movie : DBObject 
    {
        public static string table_name = "movie";
        public static string[] column_names = {"filmID", "Title", "year", "Avg_rating", "Description", "MoviePoster"};
    }

    public class Actor : DBObject
    {
        public static string table_name = "actor";
        public static string[] column_names = {"SSN", "filmID"};
    }

    public class  : DBObject
    {
        public static string table_name = "director";
        public static string[] column_names = { "SSN", "filmID" };
    }

    public class Genre : DBObject
    {
        public static string table_name = "genre";
        public static string[] column_names = {"filmID", "genre"};
    }

    public class Like : DBObject
    {
        public static string table_name = "likes";
        public static string[] column_names = {"SSN", "genre"};
    }

    public class Review: DBObject
    {
        public static string table_name = "movie_review";
        public static string[] column_names = {"filmID", "SSN", "Text", "Rating"};
    }

    public class NowPlaying : DBObject
    {
        public static string table_name = "now_playing";
        public static string[] column_names = {"TID", "filmID", "date", "time"};
    }

    public class Person : DBObject
    {
        public static string table_name = "person";
        public static string[] column_names = {"SSN", "Fname", "Lname", "gender"};
    }

    public class Recommend : DBObject
    {
        public static string table_name = "recommend";
        public static string[] column_names = {"SSN", "filmID"};
    }
    
    public class Theater : DBObject
    {
        public static string table_name = "theater";
        public static string[] column_names = {"TID", "Name", "City"};
    }

    public class User : DBObject
  
        public static string table_name = "user";
        public static string[] column_names = {"SSN", "Username", "Password"};
    }
}