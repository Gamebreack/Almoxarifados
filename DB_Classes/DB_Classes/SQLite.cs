using System;
using System.Data.SQLite;
using System.Data;

namespace DB_Classes
{
    public class DB_SQLite
    {
        private SQLiteConnection conn = new SQLiteConnection();
        private string connString = " ";
        public DB_SQLite()
        {

        }
        /// <summary>
        /// Function to generate a connection between the program and the database
        /// </summary>
        /// <param name="datasource"></param> 
        /// <returns></returns>
        public SQLiteConnection SQLite_connect(String datasource)
        {
            connString = datasource;
            try
            {
                conn = new SQLiteConnection(connString);
                return conn;
            }
            catch (Exception d)
            {
                Console.Write(d.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// Funtion to select data from your database
        /// </summary>
        /// <param name="Query"></param> Your current statements
        /// <returns></returns> Returns data in DataSet
        public DataSet SQLite_select(String Query, SQLiteConnection conx)
        {
            SQLiteConnection con = new SQLiteConnection(conx);
            SQLiteDataAdapter sqlda = new SQLiteDataAdapter(Query, con);
            DataSet ds = new DataSet();
            con.Open();
            try
            {
                sqlda.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception e)
            {
                Console.Write(e.Message.ToString());
                con.Close();
                return ds;
            }
        }
        /// <summary>
        /// Function to update the database
        /// </summary>
        /// <param name="Query"></param> Your current statements
        public void SQLite_update(String Query, SQLiteConnection conx)
        {
            SQLiteConnection con = new SQLiteConnection(conx);
            SQLiteCommand sqlcmd = new SQLiteCommand(Query, con);
            con.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception g)
            {
                Console.Write(g.Message.ToString());
                con.Close();
            }
        }
        /// <summary>
        /// Function to insert data on your database
        /// </summary>
        /// <param name="Query"></param> Your current statements
        public void SQLite_insert(String Query, SQLiteConnection conx)
        {
            SQLiteConnection con = new SQLiteConnection(conx);
            SQLiteCommand sqlcmd = new SQLiteCommand(Query, con);
            con.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception g)
            {
                Console.Write(g.Message.ToString());
                con.Close();
            }
        }
        /// <summary>
        /// Function to delete data from your database
        /// </summary>
        /// <param name="Query"></param> Your current statements
        public void SQLite_delete(String Query, SQLiteConnection conx)
        {
            SQLiteConnection con = new SQLiteConnection(conx);
            SQLiteCommand sqlcmd = new SQLiteCommand(Query, con);
            con.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception g)
            {
                Console.Write(g.Message.ToString());
                con.Close();
            }
        }
    }
}