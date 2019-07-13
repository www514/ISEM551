using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Assignment1.DataAccess
{
    public class DAGetGameDetails
    {
        //Get the game details from database but get the connection string details from web.Config file
        public static DataSet DAGetGameDetailsWithConfig()
        {
            SqlConnection cnn;
            string sql = null;
            SqlCommand command;
            SqlDataReader dataReader;

            DataTable dt = new DataTable();
            DataSet dsGetGameDetailsReport = new DataSet();

            var cs = ConfigurationManager.ConnectionStrings["GameDetailsConnection_DEV"].ConnectionString;
            cnn = new SqlConnection(cs);
            sql = "Select * from GameDetails";

            //Open the connection
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            dt.Load(dataReader);
            dsGetGameDetailsReport.Tables.Add(dt);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return dsGetGameDetailsReport;
        }

    }
}
