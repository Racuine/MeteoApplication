using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dataAccess
    {
        public CityForeCast[] GetForecastFromDatabase()
        {
            //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=weatherForecast;Integrated Security=True;Pooling=False");
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(@"Server=eu-cdbr-azure-west-c.cloudapp.net;Database=BDMeteo;Uid=b95badd8e1dbad;Pwd=bde4c7b6;Pooling=True");
            connection.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM tablemeteo", connection);
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
            List<CityForeCast> forecasts = new List<CityForeCast>();
            while (reader.Read())
            {
                CityForeCast forecast = new CityForeCast();
                forecast.City = (string)reader["City"];
                forecast.description = (string)reader["Description"];
                forecast.MaxTemp = (decimal)reader["Temperature"];
                forecasts.Add(forecast);

            }
            reader.Close(); // Fermer le reader avant de fermer la connection
            connection.Close();
            return forecasts.ToArray();
            //var ctx = new weatherForecastEntities();
            //var forecast = ctx.Tables.Select(f => new CityForeCast()
            //{
            //    City = f.City,
            //    description = f.Description,
            //    MaxTemp = (decimal)f.Temperature
            //});
            //return forecast;
        }
    }
}
