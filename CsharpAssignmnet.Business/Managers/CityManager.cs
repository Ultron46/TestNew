using AutoMapper;
using CsharpAssginment.Data.Interfaces;
using CsharpAssginment.Data.Models;
using CsharpAssignment.Business.Interfaces;
using CsharpAssignment.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment.Business.Managers
{
    public class CityManager : ICityManager
    {
        private ICityRepository _cityRepository;

        public CityManager(ICityRepository cityManager)
        {
            _cityRepository = cityManager;
        }
        public List<CityViewModel> GetAllCities()
        {
            List<City> cities = _cityRepository.GetAllCities();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<City, CityViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            List<CityViewModel> cityViewModels = mapper.Map<List<City>, List<CityViewModel>>(cities);
            return cityViewModels;
        }
    }
}
