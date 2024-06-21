using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.CQRS.Commands.BrandCommands
{
    public class RemoveBrandCommand
    {
        public RemoveBrandCommand(int brandID)
        {
            BrandID = brandID;
        }

        public int BrandID { get; set; }
       
    }
}
