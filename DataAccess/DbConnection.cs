using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DbConnection
    {
        private readonly string connectionString;

        public DbConnection()
        {
            connectionString ="Server=148.233.85.168,5015;Initial Catalog=SistemaHorarios;User Id=sa;Password=TIDSM3A2020.;";
        }

        public SqlConnection GetConnection(){
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();//Login
            return connection;
        }
    }
}
