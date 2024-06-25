using Microsoft.EntityFrameworkCore;

using RentacarDomain.Entity;
using RentacarPersistence.Context;
using Rentacarproject.RentacarApplication.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarPersistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository:ICarPricingRepository
    {
        private readonly RentacarContext _context;

        public CarPricingRepository(RentacarContext context)
        {
            _context = context;
        }

       
        public List<CarPricing> GetCarPricingsWithCar()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(u=>u.Pricing.Name=="Günlük").ToList();
            return values;
        }

        
    }
}
