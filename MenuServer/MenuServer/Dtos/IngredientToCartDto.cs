﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class IngredientToCartDto
    {
        public int IngredientCode { get; set; }
        public int CartItemCount { get; set; }
    }
}
