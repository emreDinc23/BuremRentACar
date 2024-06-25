using Microsoft.EntityFrameworkCore;
using RentacarApplication.Interfaces.BlogInterfaces;
using RentacarDomain.Entity;
using RentacarPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarPersistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly RentacarContext _context;

        public BlogRepository(RentacarContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.CreatedDate).ToList();
            return values;
        }

        public List<Blog> GetAuthorDetailByBlog(int id)
        {
            var values = _context.Blogs.Include(x => x.Author).Where(x => x.BlogID == id).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogsWithAuthor()
        {
           var values = _context.Blogs.Include(x=>x.Author).OrderByDescending(x => x.CreatedDate).Take(3).ToList();
            return values;
        }
    }
}
