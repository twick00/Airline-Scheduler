using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Airline_Planner.Models
{
    public class City
    {
        private static List<City> _allCities = new List<City>{};
        public static List<City> GetCities()
        {
            List<City> allCities = new List<City> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cities;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int cityId = rdr.GetInt32(0);
                string cityName = rdr.GetString(1);
                City newCity = new City(cityName, cityId);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            _allCities = allCities;
            return _allCities;
        }
        public static void FindCityByID(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cities WHERE id = @cityId;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int cityId = rdr.GetInt32(0);
                string cityName = rdr.GetString(1);
                City newCity = new City(cityName, cityId);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public void GetFlightsFromThisCity()
        {
            List<int> flightIdList = new List<int>{};
            MySqlConnection conn = DB.Connection(); 
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cities JOIN flights_cities ON (cities.id = flights_cities.city_id) JOIN flights ON (flights_cities.flight_id = flights.flight_id) WHERE cities.id = @cityId;";
            MySqlParameter thisCityId = new MySqlParameter();
            thisCityId.ParameterName = "@cityId";
            thisCityId.Value = this._cityId;
            cmd.Parameters.Add(thisCityId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        private static void InsertCityToDB(string cityName)
        {
            MySqlConnection conn = DB.Connection();
           conn.Open();

           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = "INSERT INTO `cities` (`id`, `city_name`) VALUES (NULL, 'Texas');";

           MySqlParameter newCity = new MySqlParameter();
           newCity.ParameterName = "@ItemDescription";
           newCity.Value = cityName;
           cmd.Parameters.Add(newCity);
           cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        } 
        public City(string cityName,int cityId, bool insertToDB = false)
        {
            this._cityId = cityId;
            this._cityName = cityName;
            _allCities.Add(this);
            if (insertToDB)
            {
                InsertCityToDB(cityName);
            }
        }
        private string _cityName;
        public string CityName { get => _cityName; set => _cityName  = value; }
        private int _cityId;
        public int CityId { get => _cityId; set => _cityId = value; }
        private List<Flight> _flightsToHere;
        private List<Flight> _flightsFromHere;
    }
}
