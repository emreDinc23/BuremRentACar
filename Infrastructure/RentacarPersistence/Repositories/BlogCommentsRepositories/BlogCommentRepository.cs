using RentacarApplication.Interfaces.BlogCommentsRepository;
using RentacarDomain.Entity;
using RentacarPersistence.Context;

namespace RentacarPersistence.Repositories.BlogCommentsRepositories
{
    public class BlogCommentRepository : IBlogCommentRepository
    {
        private readonly RentacarContext _context;

        public BlogCommentRepository(RentacarContext context)
        {
            _context = context;
        }

        public List<Comment> GetBlogCommentsByBlogId(int id)
        {
            var values = _context.Comments.Where(x => x.BlogId == id).ToList();
            return values;

        }
    }
}
