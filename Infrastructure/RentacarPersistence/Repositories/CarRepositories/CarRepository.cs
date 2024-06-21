using Microsoft.EntityFrameworkCore;
using RentacarApplication.Interfaces.CarInterfaces;
using RentacarDomain.Entity;
using RentacarPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarPersistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentacarContext _context;

        public CarRepository(RentacarContext context)
        {
            _context = context;
        }

        public List<Car> GerCarsListWithBrands()
        {
            var values = _context.Cars.Include(x=>x.Brand).ToList();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
           var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();
           return values;
        }
    }
}
