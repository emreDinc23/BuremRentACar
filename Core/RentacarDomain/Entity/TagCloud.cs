using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarDomain.Entity
{
    public class TagCloud
    {
        public int TagCloudId { get; set; }
        public string Name { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }

    }
}
