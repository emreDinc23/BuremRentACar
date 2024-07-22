namespace Rentacarproject.Dto.BlogDtos
{
    public class CreateBlogDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public string coverImageUrl { get; set; }
        public int authorId { get; set; }
        public string author { get; set; }
        public int categoryId { get; set; }
    }
}
