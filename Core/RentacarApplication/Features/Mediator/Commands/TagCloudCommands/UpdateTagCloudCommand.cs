﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApplication.Features.Mediator.Commands.TagCloudCommands
{
    public class UpdateTagCloudCommand:IRequest
    {
        

        public int TagCloudId { get; set; }
        public string Name { get; set; }
        public int BlogId { get; set; }
    }
    
    }

