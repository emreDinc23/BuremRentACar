using Microsoft.EntityFrameworkCore;
using RentacarApplication.Interfaces.TagCloudInterfaces;
using RentacarDomain.Entity;
using RentacarPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarPersistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly RentacarContext _context;

        public TagCloudRepository(RentacarContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetAllTagCloudById(int id)
        {
            var values =_context.TagClouds.Include(x => x.Blog).Where(y=>y.BlogID==id).ToList();
            return values;
            
        }
    }
}
