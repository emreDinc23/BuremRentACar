﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Results.BlogResults
{
    public class GetLast3BlogsWithAuthorQueryResult
    { 

         public int BlogID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AuthorID { get; set; }
    public int CategoryId { get; set; }
        public string AuthorName { get; set; }
}
}
