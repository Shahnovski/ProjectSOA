﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuId { get; set; }
    }
}
