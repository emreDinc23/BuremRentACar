using RentacarDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GerCarsListWithBrands();
        List<Car> GetLast5CarsWithBrands();
     

    }
}
