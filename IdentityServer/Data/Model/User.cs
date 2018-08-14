﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ew.IdentityServer.Model
{
    public class User : IdentityUser<Guid>
    {
        public string Department { get; set; }
    }
}
