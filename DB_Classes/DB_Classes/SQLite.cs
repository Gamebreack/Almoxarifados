using System;
using System.Data.SQLite;
using System.Data;

namespace DB_Classes
{
    public class DB_SQLite
    {
        private SQLiteConnection conn;

        public DB_SQLite(string datasource)
        {
            try
            {
                conn = new SQLiteConnection(datasource);
            }
            catch (Exception d)
            {
                Console.Write(d.Message.ToString());
            }
        }
        /// <summary>
        /// Funtion to select data from your database
        /// </summary>
        /// <param name="Query"></param> Your current statements
        /// <returns></returns> Returns data in DataSet
        public DataSet SQLite_select(String Query)
        {
            SQLiteDataAdapter sqlda = new SQLiteDataAdapter(Query, conn);
            DataSet ds = new DataSet();
            conn.Open();
            try
            {
                sqlda.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                Console.Write(e.Message.ToString());
                conn.Close();
                return ds;
            }
        }
        /// <summary>
        /// Function to update the database
        /// </summary>
        /// <param name="Query"></param> Your current statements
        public void SQLite_update(String Query)
        {
            SQLiteCommand sqlcmd = new SQLiteCommand(Query, conn);
            conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception g)
            {
                Console.Write(g.Message.ToString());
                conn.Close();
            }
        }
        /// <summary>
        /// Function to insert data on your database
        /// </summary>
        /// <param name="Query"></param> Your current statements
        public void SQLite_insert(String Query)
        {
            SQLiteCommand sqlcmd = new SQLiteCommand(Query, conn);
            conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception g)
            {
                Console.Write(g.Message.ToString());
                conn.Close();
            }
        }
        /// <summary>
        /// Function to delete data from your database
        /// </summary>
        /// <param name="Query"></param> Your current statements
        public void SQLite_delete(String Query)
        {
            SQLiteCommand sqlcmd = new SQLiteCommand(Query, conn);
            conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception g)
            {
                Console.Write(g.Message.ToString());
                conn.Close();
            }
        }
    }
}