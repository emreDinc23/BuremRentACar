﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacarproject.Dto.BlogDtos
{
    public class ResultAuthorDetailByBlogDto
    {
        public int BlogID { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorDescription { get; set; }
    }
}
