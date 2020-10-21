using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ScorpioJelszoMenedzser
{
    class databaseManager
    {
        public static string createTables(string connString)
        {
            SqlConnection cn = new SqlConnection(connString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("create table jelszavak (Id int,Nev TEXT, " +
                "Felhasznalonev TEXT, Email TEXT, Jelszo TEXT);", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                return "ok";
            }
            catch (Exception eq)
            {

                return eq.ToString();
            }
        }
        public static string createDatabase(string name, string dbFileName)
        {
            String str;
            SqlConnection myConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB");

            str = "CREATE DATABASE " + name + " ON PRIMARY " +
                "(NAME = ScorpioPasswordmanagerDatas, " +
                "FILENAME = '" + Form1.localFolder + "\\" + dbFileName + ".mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = MyDatabase_Log, " +
                "FILENAME = '" + Form1.localFolder + "\\" + dbFileName + ".ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                databaseConnection.dataBaseName = dbFileName;
                string connectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Form1.localFolder + "\\" + dbFileName + ".mdf";
                myCommand.ExecuteNonQuery();
                string x = createTables(connectionString);
                if (x == "ok") return "ok";
                else return "notb";

            }
            catch (System.Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
