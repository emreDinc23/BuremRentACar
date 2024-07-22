using RentacarDomain.Entity;

namespace RentacarApplication.Interfaces.BlogCommentsRepository
{
    public interface IBlogCommentRepository
    {

        public List<Comment> GetBlogCommentsByBlogId(int id);


    }
}
