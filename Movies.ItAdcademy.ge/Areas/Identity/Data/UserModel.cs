using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Movies.ItAdcademy.ge.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the UserModel class
    public class UserModel : IdentityUser
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
