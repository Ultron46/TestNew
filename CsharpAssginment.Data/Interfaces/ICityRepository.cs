using CsharpAssginment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssginment.Data.Interfaces
{
    public interface ICityRepository
    {
        List<City> GetAllCities();
    }
}
