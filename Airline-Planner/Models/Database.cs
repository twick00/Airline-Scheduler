using System;
using MySql.Data.MySqlClient;
using Airline_Planner;

namespace Airline_Planner.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}