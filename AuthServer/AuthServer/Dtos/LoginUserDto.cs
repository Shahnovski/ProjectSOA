﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Dtos
{
    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
