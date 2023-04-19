using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineBookStore.Models
{
    public class Functions
    {

        private SqlConnection connection;
        private SqlCommand command;
        private DataTable dataTable;
        private SqlDataAdapter dataAdapter;
        private string connection_string;

        public Functions()
        {
            connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Book_Store;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            connection = new SqlConnection(connection_string);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public DataTable GetData(string Query)
        {
            dataTable = new DataTable();
            dataAdapter = new SqlDataAdapter(Query, connection_string);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public int SetData(string Query)
        {
            int count = 0;

            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command.CommandText = Query;
            count = command.ExecuteNonQuery();
            connection.Close();
            return count;
        }
    }
}