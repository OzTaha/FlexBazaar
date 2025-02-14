using Microsoft.AspNetCore.Identity;

namespace FlexBazaar.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
