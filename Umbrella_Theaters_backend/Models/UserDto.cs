using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }

    }
}