namespace Rentacarproject.Dto.BlogDtos
{
    public class UpdateBlogDto
    {


        public int blogID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public int authorID { get; set; }
        public int categoryId { get; set; }


    }
}
