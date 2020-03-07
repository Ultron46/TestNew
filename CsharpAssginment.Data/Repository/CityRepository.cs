using CsharpAssginment.Data.Interfaces;
using CsharpAssginment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssginment.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        public List<City> GetAllCities()
        {
            List<City> cities;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                cities = db.Cities.ToList() ?? new List<City>();
            }
            return cities;
        }
    }
}
