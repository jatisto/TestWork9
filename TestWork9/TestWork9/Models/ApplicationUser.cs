using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TestWork9.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Code { get; set; }
        public double Balance { get; set; }

        public static explicit operator double(ApplicationUser v)
        {
            throw new NotImplementedException();
        }
    }
}