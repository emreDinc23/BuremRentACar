using Microsoft.AspNetCore.Mvc;
using RentacarApplication.Features.RepositoryPattern;
using RentacarApplication.Interfaces.BlogCommentsRepository;
using RentacarDomain.Entity;

namespace Rentacar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IBlogCommentRepository _blogCommentRepository;


        public CommentsController(IGenericRepository<Comment> commentRepository, IBlogCommentRepository blogCommentRepository)
        {
            _commentRepository = commentRepository;
            _blogCommentRepository = blogCommentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var comments = _commentRepository.GetAll();
            return Ok(comments);
        }
        [HttpPost]
        public IActionResult Post(Comment comment)
        {
            _commentRepository.Add(comment);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public IActionResult Put(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok(comment);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentRepository.Delete(id);
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var comment = _commentRepository.GetById(id);
            return Ok(comment);
        }
        [HttpGet]
        [Route("GetBlogCommentsByBlogId/{id}")]
        public IActionResult GetBlogCommentsByBlogId(int id)
        {
            var comments = _blogCommentRepository.GetBlogCommentsByBlogId(id);
            return Ok(comments);
        }

    }
}
