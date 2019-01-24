using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight.AspNetCore.Auth.Web.Services
{
    public interface IProfileService
    {
        Task<UserProfile> GetUserProfileAsync(string userId);
    }

    public class UserProfile
    {
        public UserProfile(string firstname, string lastName, string[] roles)
        {
            Firstname = firstname;
            LastName = lastName;
            Roles = roles;
        }

        public string Firstname { get; }
        public string LastName { get; }
        public string[] Roles { get; }
    }
}
