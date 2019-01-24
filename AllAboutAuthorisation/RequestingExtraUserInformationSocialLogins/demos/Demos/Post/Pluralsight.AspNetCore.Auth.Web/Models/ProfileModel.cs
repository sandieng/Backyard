﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight.AspNetCore.Auth.Web.Models
{
    public class ProfileModel
    {
        [Required(ErrorMessage = "Have to supply a display name")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Have to supply an e-mail address")]
        [EmailAddress(ErrorMessage = "The e-mail address format looks a bit off...")]
        public string Email { get; set; }
    }
}
