using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ScorpioJelszoMenedzser
{
    class databaseConnection
    {
        public static string dataBaseName;
        //public static string connectionString =
        //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True;User Instance = False";
        public static string connectionString;
         

        public static DataTable updateList()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Form1.localFolder + "\\" + dataBaseName + ".mdf;Integrated Security=True;User Instance = False";
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * FROM jelszavak", con))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        //dt = null;
                        dataAdapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public static int maxItemsCount()
        {
            int max = 0;

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX (ID) FROM jelszavak", con);
            try
            {
                max = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            {
                max = 0;
            }
            SqlDataReader data = cmd.ExecuteReader();
            con.Close();
            return max;
        }
        public static string deleteDatasByID(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM jelszavak WHERE id = @id", con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static string addNewItemToDatabase(string nev, string felhasz, string email, string jelszo)
        {
            int MaxId = maxItemsCount();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO jelszavak(Id, Nev, Felhasznalonev, Email, Jelszo)VALUES(@ID, @NEV, @FEL, @EMAIL, @JELSZO)", con);
                command.Parameters.AddWithValue("@ID", MaxId + 1);
                command.Parameters.AddWithValue("@NEV", nev);
                command.Parameters.AddWithValue("@FEL", felhasz);
                command.Parameters.AddWithValue("@EMAIL", email);
                command.Parameters.AddWithValue("@JELSZO", jelszo);
                command.ExecuteNonQuery();
                con.Close();
                return "helyes";
                
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
