using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment.BusinessEntities.ViewModels
{
    public class CityViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public System.DateTime Created_Date { get; set; }
        public Nullable<System.DateTime> Updated_Date { get; set; }
    }
}
