﻿using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class ApplicationUser :IdentityUser
    {
        public String Address { get; set; }

    }
}
