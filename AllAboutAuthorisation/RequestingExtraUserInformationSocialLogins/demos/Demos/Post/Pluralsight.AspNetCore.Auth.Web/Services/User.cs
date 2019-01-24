﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight.AspNetCore.Auth.Web.Services
{
    public class User
    {
        private User()
        {

        }

        public static User Create(string id, string displayname, string email)
        {
            return new User {
                Id = id,
                DisplayName = displayname,
                Email = email
            };
        }

        public string Id { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }
    }
}
