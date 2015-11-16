using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class ForecastController : ApiController
    {
        public CityForeCast[] Get(string region = null)
        {

            return GetForecastFromDatabase().OrderBy(forecast => forecast.City).ToArray();

        }
        private CityForeCast[] GetForecastFromDatabase()
        {
            dataAccess dA = new dataAccess();
            return dA.GetForecastFromDatabase();
        }
    }
 
}
