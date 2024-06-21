using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarDomain.Entity
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<Blog> blogs { get; set; }
    }
}
